using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for ucEmployeeManager.xaml
    /// </summary>
    public partial class ucEmployeeManager : UserControl
    {
        private EmployeeViewModel _viewModel;
        private IDepartmentService _serviceDept;
        public ucEmployeeManager()
        {
            _viewModel = new EmployeeViewModel();
            _serviceDept = new DepartmentService();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnEditEmployee(object sender, System.Windows.RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;
            _viewModel.EmpId = employee.empId;
            _viewModel.EmpFirstName = employee.empFirstName;
            _viewModel.EmpLastName = employee.empLastName;
            _viewModel.EmpTitle = employee.empTitle;
            _viewModel.EmpDob = employee.empDob;
            _viewModel.Address = employee.Address;
            _viewModel.PhoneNumber = employee.phoneNumber;
            _viewModel.NextOfKin = employee.nextOfKin;
            _viewModel.EmpCategory = employee.empCategory;
            _viewModel.EmpJob = employee.empJob;
            _viewModel.EmpCode = employee.empCode;
            _viewModel.Passport = employee.passport;
        }

        private void btnDeleteEmployee(object sender, System.Windows.RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;
            _viewModel.empId = employee.empId;
            if (_viewModel.EmpId != 0)
            {
                _viewModel.DeleteEmployee();
            }
           

        }

        private void cboDepartment_Initialized(object sender, System.EventArgs e)
        {
            fillDeptComboBox();
        }
        async void fillDeptComboBox()
        {
            try
            {
                var combodata = await _serviceDept.GetDepts();
                if (combodata != null)
                {
                    foreach (var item in combodata)
                    {
                        cboDepartment.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
