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
        private EmployeeManagerViewModel _viewModel;
        private IDepartmentService _serviceDept;
        private ICategoryService _serviceCat;
        public ucEmployeeManager()
        {
            _viewModel = new EmployeeManagerViewModel();
            _serviceDept = new DepartmentService();
            _serviceCat = new CategoryService();
           
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void btnEditEmployee(object sender, System.Windows.RoutedEventArgs e)
        {
            Employee employee = ((FrameworkElement)sender).DataContext as Employee;


            _viewModel.EmpCode = employee.empCode;
            _viewModel.EmpFirstName = employee.empFirstName;
            _viewModel.EmpLastName = employee.empLastName;
            _viewModel.NextOfKin = employee.nextOfKin;
            _viewModel.PhoneNumber = employee.phoneNumber;
            _viewModel.EmpId = employee.empId;
            _viewModel.EmpDob = employee.empDob;
            _viewModel.EmpCategory = employee.empCategory;
            _viewModel.EmpTitle = employee.empTitle;
            _viewModel.Gender = employee.gender;
            _viewModel.AccountNumber = employee.accountNumber;
            _viewModel.Passport = employee.passport;
            _viewModel.Address = employee.Address;

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
            fillDeptCombo();
        }
        async void fillDeptCombo()
        {
            try
            {
                var combodata = await _serviceDept.GetDepts();
                if (combodata != null)
                {
                    foreach (var item in combodata)
                    {
                        cboDepartment.Items.Add(item.Name);
                        cboDepartmen.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void cboCategory_Initialized(object sender, EventArgs e)
        {
            fillCatComboBox();
        }

        private void btnClickPassport(object sender, RoutedEventArgs e)
        {

        }
        async void fillCatComboBox()
        {
            try
            {
                var combodata = await _serviceCat.GetCats();
                if (combodata != null)
                {
                    foreach (var item in combodata)
                    {
                        cboCategory.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }


        private void cboCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        //async void fillDeptComboBox()
        //{
        //    try
        //    {
        //        var combodata = await _serviceDept.GetDepts();
        //        if (combodata != null)
        //        {
        //            foreach (var item in combodata)
        //            {
        //                cboDepartmen.Items.Add(item.Name);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }

        //}
    }
}
