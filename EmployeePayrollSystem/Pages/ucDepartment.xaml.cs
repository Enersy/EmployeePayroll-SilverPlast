using EmployeePayroll.Domain.Repository;
using EmployeePayroll.Domain.Entities;
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

namespace EmployeePayrollSystem.Pages
{
    /// <summary>
    /// Interaction logic for ucDepartment.xaml
    /// </summary>
    public partial class ucDepartment : UserControl
    {
        protected Department department;
        private readonly IUnitOfWork _unitOfWork;
        public ucDepartment()
        {
            InitializeComponent();
            
        }
      


       
    }
}
