using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class EmployeeManagerViewModel
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
        [ObservableProperty]
        public Employee selectedEmployee;

        [ObservableProperty]
        public Employee employee;



        private readonly IEmployeeService _service;

        public EmployeeManagerViewModel()
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
                if (EmpId != 0)
                {
                    var response = await _service.UpdateEmployee(employee);
                    //  
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee Record Updated Successfully", "Update Operation");
                        LoadData();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Operation");
            }

            ClearField();

        }

        [RelayCommand]
        public async Task SearchEmployee()
        {
            var emp = from item in EmpList
                      where item.empTitle == EmpTitle && item.empCode == EmpCode
                      select item;
            if (emp != null)
            {
                QuerryResultList = new ObservableCollection<Employee>(emp.ToList());
            }
            else
            {
                MessageBox.Show("Staff Record not Found", "Query Operation");
            }
        }


        public async void DeleteEmployee()
        {
            var response = await _service.DeleteEmployee(EmpId);
            if (response.IsSuccessStatusCode)
            {
                if (QuerryResultList.Count != 0)
                {

                    QuerryResultList.RemoveAt(0);
                    LoadData();
                }

            }
        }


        public async Task LoadData()
        {
            var response = await _service.GetEmployees();
            if (response != null)
            {
                EmpList = new ObservableCollection<Employee>(response);
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

