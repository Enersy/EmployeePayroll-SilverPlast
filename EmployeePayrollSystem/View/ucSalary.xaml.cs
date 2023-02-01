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
    /// Interaction logic for ucSalary.xaml
    /// </summary>
    public partial class ucSalary : UserControl
    {
        private SalaryViewModel _viewModel;
        public ucSalary()
        {
            _viewModel = new SalaryViewModel();
            DataContext = _viewModel;
            InitializeComponent();
             txtOtherBonus.IsEnabled = false;
            
             txtTax.Visibility = Visibility.Collapsed;
            
        }

        private void cboDateFrom_Initialized(object sender, EventArgs e)
        {

        }

        private void cboDateTo_Initialized(object sender, EventArgs e)
        {
            
        }


        private void cbotherAll_Checked(object sender, RoutedEventArgs e)
        {
            if (cbotherAll.IsChecked.Equals(true))
            {

                txtOtherBonus.IsEnabled = true;
            }

        }

        private void cbotherAll_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbotherAll.IsChecked.Equals(false))
            {
                txtOtherBonus.IsEnabled = false;
            }

        }

      
        private void cbOvertime_Checked(object sender, RoutedEventArgs e)
        {
            if (cbOvertime.IsChecked.Equals(true))
            {
                cbOvertime.Visibility = Visibility.Visible;
            }
        }

        private void cbOvertime_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbOvertime.IsChecked.Equals(false))
            {
                cbOvertime.Visibility = Visibility.Collapsed;
            }
        }

        private void cbTax_Checked(object sender, RoutedEventArgs e)
        {
            if (cbTax.IsChecked.Equals(true))
            {
                txtTax.Visibility = Visibility.Visible;
            }
        }
        private void cbTax_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbTax.IsChecked.Equals(false))
            {
                txtTax.Visibility = Visibility.Collapsed;
            }
        }
    }
}
