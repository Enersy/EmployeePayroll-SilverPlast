using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeePayrollSystem.ViewModels
{   [ObservableObject]
    public partial class EmployeeAttendanceViewModel
    {
        public int Id { get; set; }
        [ObservableProperty]
        public string employeeName;
        [ObservableProperty]
        public string employeeCode;
        [ObservableProperty]
        public DateTime timeIn = DateTime.Now;
        [ObservableProperty]
        public DateTime timeOut = DateTime.Now;
        [ObservableProperty]
        public double totalTime ;
        [ObservableProperty]
        public double totalHours = 8;
        [ObservableProperty]
        public DateTime todaysDate = DateTime.Parse(DateTime.Now.ToShortTimeString());
        [ObservableProperty]
        public ObservableCollection<Attendance> attendanceList;

        [ObservableProperty]
        public ObservableCollection<Attendance> dgattendanceList;

        [ObservableProperty]
        public string shift;
        private AttendanceService _service;
        private EmployeeService _empservice;

        private IEnumerable<Employee> employees;


        public EmployeeAttendanceViewModel()
        {
            _service = new AttendanceService();
            _empservice = new EmployeeService();
            attendanceList = new ObservableCollection<Attendance>( );
            LoadData();
        }

        private async void LoadData()
        {
            var data = await _service.GetAttencdances();
            if (data !=null)
            {
                var todaysRegister = from item in data
                                     where item.DateCreated == DateTime.Now.Date
                                     select item;
                    attendanceList = new ObservableCollection<Attendance>(data);
                DisplayData();

            }

            var empdata = await _empservice.GetEmployees();
            if (empdata != null)
                employees = empdata;
           
        }


        [RelayCommand]
        private async void GetStaff()
        { 
            //_empservice.GetEmployees
        }

            [RelayCommand]
        private async void SaveRegister()
        {
            Attendance Attendance = new Attendance();
            var emp = employees.Where(x=>x.empCode.Equals(EmployeeCode)).FirstOrDefault();
            if (emp != null)
            {
                
                Attendance.InTime = TimeIn;
                Attendance.OutTime = TimeOut;
                Attendance.TotalTime = 0.0;
                Attendance.TotalHrs = TotalHours;
                Attendance.DateCreated = todaysDate;
                Attendance.EmpName = String.Concat(emp.empFirstName + " " + emp.empLastName);
                Attendance.EmpCode = emp.empCode;
                Attendance.Shift = Shift;
            }
            try
            {
                if (Attendance.Id == 0)
                {
                  var response =  await _service.SaveAttendance(Attendance);
                    if (response.IsSuccessStatusCode)
                    {
                        LoadData();
                        MessageBox.Show("Record Saved Successfully", "Save Operation");
                        DisplayData();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Operation");
            }


           
        }
        DbFunctions db;
        private  void DisplayData()
        {
            if (attendanceList != null)
            {
                var myDGVlist = new List<Attendance>(attendanceList);

                if (myDGVlist != null)
                {

                    foreach (var item in attendanceList)
                    {
                        myDGVlist = new List<Attendance>
                        {
                          new Attendance{
                            TotalTime =item.TotalTime,
                            TotalHrs = item.TotalHrs,
                            EmpCode = item.EmpCode,
                            EmpName = item.EmpName,
                            Shift = item.Shift,
                            DateCreated = item.DateCreated
                            
                          }
                        };
                    }


                   
                    dgattendanceList = new ObservableCollection<Attendance>( myDGVlist.ToList());
                }
            }

        }
    }

}
