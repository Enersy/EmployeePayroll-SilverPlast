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
        protected Department department;
        public DepartmentService service;
        public DepartmentViewModel ViewModel;
       private CategoryService categoryService; 


        public  ucDepartment()
        {
            
            service = new  DepartmentService();
            ViewModel =new   DepartmentViewModel();
            department = new Department();
             categoryService = new CategoryService();
                InitializeComponent();
        
        }
        


        private async void Button_Update(object sender, RoutedEventArgs e)
        {
            var response = await service.GetDept(Convert.ToInt32(txtDeptId.Text));
            if (response != null) 
            {
                response.Code = txtDeptCode.Text;   
                response.Name = txtDeptName.Text;

                 service.UpdateDepts(response);
            }
           
        }
       
       

       void btnEditDept(object sender, RoutedEventArgs e) 
        {
            Department dept =((FrameworkElement)sender).DataContext as Department;
            txtDeptId.Text = dept.Id.ToString();
            txtDeptCode.Text = dept.Code;
            txtDeptName.Text =dept.Name;
            txtDeptDescription.Text = dept.Description;
            cboCategory.Text=dept.Category;

        }
        async void btnDeleteDept(object sender, RoutedEventArgs e)
        {
            Department dept = ((FrameworkElement)sender).DataContext as Department;
            service.DeleteDepts(dept);

            dgDeptDetails.ItemsSource = ViewModel.Deptlist;
            dgDeptDetails.Items.Refresh();

        }

        async void fillComboBox()
        {
            try
            {
                var combodata =await  Catserv.GetCats();
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
