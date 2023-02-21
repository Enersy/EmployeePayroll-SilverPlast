using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class EmployeeViewModel
    {
        [ObservableProperty]
        public int empId;
        [ObservableProperty]
        public string empCode;
        [ObservableProperty]
        public string empFirstName;
        [ObservableProperty]
        public string empLastName;
        [ObservableProperty]
        public string empTitle;
        [ObservableProperty]
        public string empCategory;
        [ObservableProperty]
        public DateTime empDob;
        [ObservableProperty]
        public DateTime empJob;
        [ObservableProperty]
        public string nextOfKin;
        [ObservableProperty]
        public string phoneNumber;
        [ObservableProperty]
        public string address;
        [ObservableProperty]
        public string passport;
        [ObservableProperty]
        public ObservableCollection<Employee> empList;
        [ObservableProperty]
        public ObservableCollection<Employee> querryResultList;
        [ObservableProperty]
        public string gender;
        [ObservableProperty]
        public string accountNumber;
      
        private readonly IEmployeeService _service;
        
        public EmployeeViewModel()
        {
            _service = new EmployeeService();
            LoadData();
        }


        [RelayCommand]
        public async Task EmpSave()
        {
            Employee employee = new Employee();
            employee.phoneNumber = PhoneNumber;
            employee.empLastName = EmpLastName;
            employee.empTitle = EmpTitle;
            employee.empCategory = EmpCategory;
            employee.empDob = EmpDob;
            employee.empJob = EmpJob;
            employee.nextOfKin = NextOfKin;
            employee.empCode = EmpCode;
            employee.Address = Address;
            employee.empFirstName = EmpFirstName;
            employee.passport = Passport;
            employee.empId = EmpId;
            employee.gender = Gender;
            employee.accountNumber = AccountNumber;

            try
            {
                if (employee.empId == 0)
                {
                    var response = await _service.SaveEmployee(employee);
                    //  
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee Record Saved Successfully", "Save Operation");
                    }
                }
               
                   
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Operation");
            }

            ClearField();

        }

      
        
        public async Task LoadData() 
        {
           var response = await _service.GetEmployees();
            if (response != null)
            {
                EmpList = new ObservableCollection<Employee>( response );
            }
            
        }

        private void ClearField()
        {
            PhoneNumber = "";
            EmpLastName = "";
            EmpTitle = "";
            EmpCategory = "";
            EmpDob = DateTime.Now.Date;
            EmpJob = DateTime.Now.Date;
            NextOfKin = "";
            EmpCode = "";
            Address = "";
            EmpFirstName = "";
            Passport = "";
            EmpId = 0;
            
        }
      
    }
}
