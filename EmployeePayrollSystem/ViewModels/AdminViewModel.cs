using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class AdminViewModel
    {
        [ObservableProperty]
        public string username;
        [ObservableProperty]
        public string passowrd;
        [ObservableProperty]
        public string role;
        [ObservableProperty]
        public string empName;

        public AdminService _adminService { get; set; }

        public AdminViewModel()
        {
            _adminService = new AdminService();
        }

       

        [RelayCommand]
        private async Task saveAdminAsync() 
        {
            Admin admin = new Admin
            {
                username = Username,
                role = Role,
                password = Passowrd,
                EmpName = EmpName,
            };

          await  _adminService.SaveAdmin(admin);

        }
    }
}
