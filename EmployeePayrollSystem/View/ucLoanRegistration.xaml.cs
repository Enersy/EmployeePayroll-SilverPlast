using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for ucLoanRegistration.xaml
    /// </summary>
    public partial class ucLoanRegistration : UserControl
    {
        public LoanViewModel _viewModdel;
        public EmployeeService _service;
        public ucLoanRegistration()
        {
            _viewModdel = new LoanViewModel();
            
            DataContext = _viewModdel;
            _service= new EmployeeService();
            InitializeComponent();
          //  _viewModdel.loadEmployee();

        }

        

        private async void cboEmployee_Initialized(object sender, EventArgs e)
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

        private void txtInstallment_TextChanged(object sender, TextChangedEventArgs e)
        {
           

        }

        private void cboEmployee_DropDownClosed(object sender, EventArgs e)
        {
            if (_viewModdel.EmpList != null)
            {
                var result = _viewModdel.EmpList.FirstOrDefault(x => x.empCode.Equals(cboEmployee.Text, StringComparison.OrdinalIgnoreCase));
                if (result != null)
                {
                    _viewModdel.EmpName = string.Concat(result.empFirstName + " " + result.empLastName);
                }
                else
                {
                    _viewModdel.EmpName = String.Empty;
                }
            }
        }

        private void txtInstallment_LostFocus(object sender, RoutedEventArgs e)
        {
            var amount = Convert.ToDouble(txtLoanAmount.Text);
            var installment = Convert.ToDouble(txtInstallment.Text);
            if (installment != 0)
            {
                _viewModdel.RepaymentAmount = amount / installment;
            }
        }
    }
}
