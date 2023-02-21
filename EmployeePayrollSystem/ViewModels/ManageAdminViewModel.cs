using CommunityToolkit.Mvvm.ComponentModel;
using EmployeePayrollSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class ManageAdminViewModel
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
        public ManageAdminViewModel()
        {

        }
    }
}
