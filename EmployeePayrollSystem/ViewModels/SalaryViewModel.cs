using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class SalaryViewModel
    {
        private CategoryService categoryService;
        private EmployeeService employeeService;
        private SalaryMatrixService salaryMatrixService;
        private DepartmentService departmentService;
        private SalaryDetailsService salaryDetailsService;
        private AttendanceService attendanceService;

        private IEnumerable<Category> categories;
        private IEnumerable<Department> departments;
        private IEnumerable<Employee> employees;
        private IEnumerable<Attendance> attendances;
        private IEnumerable<SalaryMatrix> salaryMatrices;


        [ObservableProperty]
        private DateTime startDate;

        [ObservableProperty]
        private DateTime endDate;
        [ObservableProperty]
        private string empCode;
        [ObservableProperty]
        private string empName;
        [ObservableProperty]
        private double empDayRate;
        [ObservableProperty]
        private string empTitle;
        [ObservableProperty]
        private double empHouseAllowance;
        [ObservableProperty]
        private double empUtilityAllowance;
        [ObservableProperty]
        private double empTpFeedingAllowance;
        [ObservableProperty]
        private double empOtherAllowance;
        [ObservableProperty]
        private double empOverTimeAllowance;
        [ObservableProperty]
        private EmpSalaryDetails empSalary;

        DbFunctions db;

        public SalaryViewModel()
        {
            this.salaryDetailsService = new SalaryDetailsService();
            this.departmentService = new DepartmentService();
            this.salaryMatrixService = new SalaryMatrixService();
            this.employeeService = new EmployeeService();
            this.categoryService = new CategoryService();
            this.attendanceService = new AttendanceService();
             LoadData();
        }

        [RelayCommand]
        private async Task GetEmpSchedule() 
        {
            if (!string.IsNullOrEmpty( empCode))
            {
                var emp = employees.FirstOrDefault(x => x.empCode.Equals(EmpCode));
                if (emp != null) 
                {
                    
                    EmpName = String.Concat(emp.empFirstName + " " + emp.empLastName);
                    EmpTitle = emp.empTitle;
                    EmpDayRate = getEmpSalary(emp.empTitle).DayRate;
                    EmpHouseAllowance = getEmpSalary(emp.empTitle).HouseAllowanceRate;
                    EmpTpFeedingAllowance = getEmpSalary(emp.empTitle).TPFeedingAllowanceRate;
                    EmpUtilityAllowance = getEmpSalary(emp.empTitle).UtilityAllowanceRate;
                    EmpOverTimeAllowance = getEmpOvertimeWages(emp.empTitle);
                }
            }
            else
            {
                MessageBox.Show("Please enter Staff Code");
            }
            
        }

        private SalaryMatrix getEmpSalary(string code)
        {
            SalaryMatrix dayrate = null ;
            if (!string.IsNullOrEmpty(code))
            {
                
                 dayrate = salaryMatrices.FirstOrDefault(x => x.Department.Equals( code) );

            }
           
                return dayrate;
        }
        private IEnumerable<Attendance> getEmpAttendance(string code)
        {
            
            IEnumerable<Attendance> attendance = null;
            if (!String.IsNullOrEmpty(code))
            {
                attendance = attendances.Where(a => a.DateCreated >= startDate && a.DateCreated < endDate);
                   // .Count(t => db.DateDiffHour(t.OutTime,t.InTime)>0);
               

            }

            return attendance;
        }

        private double getEmpTotaltimeWorked(string code)
        {

            double attendance = 0;
            
              var empTotalTimeWorked =  getEmpAttendance(code)
                .Where(t => db.DateDiffHour(t.OutTime,t.InTime)>0).Sum(t=>t.TotalTime);


            return attendance;
        }
        private double getEmpOvertime(string code)
        {
            double totalTimeWorked;
            double totalHours;
            double overtimehours = 0;
            totalTimeWorked = getEmpTotaltimeWorked(code);
            totalHours = getEmpAttendance(code).Sum(w=>w.TotalHrs);   
            if (totalTimeWorked > totalHours)
            {

                overtimehours = totalTimeWorked - totalHours;
                //var empTotalTimeWorked = getEmpAttendance(emp)
                //  .Where(t => db.DateDiffHour(t.OutTime, t.InTime) > 0).Sum(t => t.TotalTime);
            }
            else
            {
                overtimehours = 0;
            }

            return overtimehours;
        }
        private double getEmpOvertimeWages(string code)
        {
            double overtimewage = 0;
            double overtimehour = 0;

            overtimehour = getEmpOvertime(code);
            var rate = getEmpSalary(code).HourlyRate * 1.5;

            overtimewage = rate  * overtimehour; 
          
            return overtimewage;
        }


        public async Task LoadData()
        {
            categories = await categoryService.GetCats();
            departments = await departmentService.GetDepts();
            salaryMatrices = await salaryMatrixService.GetSalaryMaxs();
            employees = await employeeService.GetEmployees();
            attendances = await attendanceService.GetAttencdances();
        }

        private  void GetEmployeeSchedule(string empCode)
        {
          var emp = employees.Where(e=>e.empCode == empCode).FirstOrDefault();
           empSalary.empBasic =26 * salaryMatrices.Where(dep => dep.Equals(emp.empTitle)).FirstOrDefault().DayRate;
          var att = attendances.Where(a=>a.EmpCode.Equals(empCode)).Count(s=>s.TotalHrs > 0);
            var sal = new EmpSalaryDetails
            {
                EmployeeName = String.Concat(emp.empFirstName + " " + emp.empLastName),

                
            };
                             
                             
        }
      
    }
}
