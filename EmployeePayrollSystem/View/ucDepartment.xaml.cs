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
using System.Net.Http;
using Newtonsoft.Json;
using EmployeePayrollSystem.Services;
using Microsoft.AspNetCore.Http;
using EmployeePayrollSystem.ViewModels;

namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for ucDepartment.xaml
    /// </summary>
    public partial class ucDepartment : UserControl
    {
       
       
        public DepartmentViewModel ViewModel;
       private ICategoryService categoryService;
        


        public  ucDepartment()
        {
            ViewModel = new   DepartmentViewModel();
            DataContext = ViewModel;
             categoryService = new CategoryService();
             InitializeComponent();
           // ViewModel.loadData();
        }
        

        void btnEditDept(object sender, RoutedEventArgs e) 
        {
            Department dept =((FrameworkElement)sender).DataContext as Department;
            ViewModel.code = dept.Code;
            ViewModel.name = dept.Name;
            ViewModel.description = dept.Description;
            ViewModel.category = dept.Category;
            
           

        }
        async void btnDeleteDept(object sender, RoutedEventArgs e)
        {
            Department dept = ((FrameworkElement)sender).DataContext as Department;
            //service.DeleteDepts(dept);

            dgDeptDetails.ItemsSource = ViewModel.Deptlist;
            dgDeptDetails.Items.Refresh();

        }

        async void fillComboBox()
        {
            try
            {
                var combodata = await categoryService.GetCats();
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

       

        private void cboCategory_Initialized(object sender, EventArgs e)
        {
            fillComboBox();
        }
    }
}
