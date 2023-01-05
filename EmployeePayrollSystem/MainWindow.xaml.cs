
using EmployeePayroll.Domain.Repository;
using EmployeePayrollSystem.Pages;
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

namespace EmployeePayrollSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnClickDepartment(object sender, RoutedEventArgs e)
        {
            Main.Content =  new ucDepartment();
        }

        private void BtnClickCategory(object sender, RoutedEventArgs e)
        {
            Main.Content =  new ucCategory();
        }
    }
}
