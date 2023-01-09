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

namespace EmployeePayrollSystem.Pages
{
    /// <summary>
    /// Interaction logic for ucDepartment.xaml
    /// </summary>
    public partial class ucDepartment : UserControl
    {
        protected Department department;
        public DepartmentService service;
        public CategoryService Catservice;


        public  ucDepartment()
        {
            
            service = new  DepartmentService();
            Catservice =new   CategoryService();
            department = new Department();
                InitializeComponent();
            Loaddata();
        }
        async void Loaddata() 
        {
            dgDeptDetails.CanUserAddRows= false;
            dgDeptDetails.DataContext = await service.GetDepts();
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            var dept = new Department()
            {
                Code = txtDeptCode.Text,
                Name = txtDeptName.Text,
                Category = cboCategory.Text,
                Description = txtDeptDescription.Text,
                Id= Convert.ToInt32(txtDeptId.Text)
            };
            
            if (dept.Id == 0)
            {
               await service.SaveDept(dept);
              //  MessageBox.Show("Department Saved Successfully");
               
                dgDeptDetails.ItemsSource = await service.GetDepts();
                dgDeptDetails.SelectedIndex = -1;
                dgDeptDetails.Items.Refresh();
            }
            else
            {
                 service.UpdateDepts(dept);
                // MessageBox.Show("Departmenr Updated Successfully");
                  
                dgDeptDetails.ItemsSource = await service.GetDepts();   
                dgDeptDetails.Items.Refresh();

            }

            txtDeptCode.Text = "";
            txtDeptName.Text = "";
            txtDeptDescription.Text = "";
            cboCategory.Text = "";
          
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
     
            dgDeptDetails.ItemsSource = await service.GetDepts();
            dgDeptDetails.Items.Refresh();

        }

        async void fillComboBox()
        {
            try
            {
                var combodata =await  Catservice.GetCats();
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
