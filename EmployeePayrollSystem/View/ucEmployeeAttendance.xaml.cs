using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for ucEmployeeAttendance.xaml
    /// </summary>
    public partial class ucEmployeeAttendance : UserControl
    {
        private EmployeeAttendanceViewModel _viewModel;
        private EmployeeService _service;
        public ucEmployeeAttendance()
        {
            _viewModel = new EmployeeAttendanceViewModel();
            DataContext = _viewModel;
            _service = new EmployeeService(); 
            InitializeComponent();

            
        }

        private async void cboEmployee_Initialized(object sender, System.EventArgs e)
        {
            try
            {
                var combodata = await _service.GetEmployees();
                if (combodata != null)
                {
                    foreach (var item in combodata)
                    {
                        cboEmployee.Items.Add(item.empCode);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Source.ToString(), ex.Message);
            }
        }
    }
    
}
