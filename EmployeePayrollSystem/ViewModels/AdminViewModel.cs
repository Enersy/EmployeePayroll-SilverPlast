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
using System.Windows.Controls;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class AdminViewModel
    {
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public string username;
        [ObservableProperty]
        public string passowrd;
        [ObservableProperty]
        public string role;
        [ObservableProperty]
        public string empName;

        [ObservableProperty]
        public ObservableCollection<Admin> adminList;
        [ObservableProperty]
        public ObservableCollection<Admin> admindataList;
        public AdminService _adminService { get; set; }

        public AdminViewModel()
        {
            _adminService = new AdminService();
            Loaddata();
        }

       

      //  [RelayCommand]
        private async Task saveAdministrator() 
        {
            
            Admin admin = new Admin
            {
                username = Username,
                role = Role,
                password = Passowrd,
                EmpName = EmpName,
            };

         var response = await  _adminService.SaveAdmin(admin);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Employee Record Saved Successfully", "Save Operation");
                adminList.Add(admin);
            }

        }
        private async Task Loaddata() 
        {
            var data = await _adminService.GetAdmins();
            AdmindataList = new ObservableCollection<Admin>(data);
            AdminList = AdmindataList;
        }
    }
}
