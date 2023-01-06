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

namespace EmployeePayrollSystem.Pages
{
    /// <summary>
    /// Interaction logic for ucDepartment.xaml
    /// </summary>
    public partial class ucDepartment : UserControl
    {
        protected Department department;
        private readonly IUnitOfWork _unitOfWork;
        private HttpClient client;
        public ucDepartment()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
            department = new Department();
            InitializeComponent();
            
        }

        private async void Button_Save(object sender, RoutedEventArgs e)
        {
            var dept = new Department()
            {
                Code = txtDeptCode.Text,
                Name = txtDeptName.Text
            };

            if (dept.Id == 0)
            {
               await this.SaveDept(dept);
                MessageBox.Show("Department Saved Successfully");
            }
            else
            {
                await this.UpdateDepts(dept);
                MessageBox.Show("Departmenr Updated Successfully");
            }

            txtDeptCode.Text = "";
            txtDeptName.Text = "";
            dgDeptDetails.DataContext = await GetDepts();
        }

        private async Task SaveDept(Department department) 
        {
            await client.PostAsJsonAsync("Department", department);
        }

        private async Task<IEnumerable<Department>> GetDepts()
        {
           var response = await client.GetStringAsync("Department");
            return JsonConvert.DeserializeObject<IEnumerable<Department>>(response).ToList();
        }

        private void Button_Update(object sender, RoutedEventArgs e)
        {
            UpdateDepts(department);
        }
        private async Task UpdateDepts(Department department)
        {
            await client.PutAsJsonAsync("Department/"+ department.Id, department);
            
        }
        private async Task DeleteDepts(int Id)
        {
            await client.DeleteAsync("Department/" + Id);

        }

       void btnEditDept(object sender, RoutedEventArgs e) 
        {
            Department dept =((FrameworkElement)sender).DataContext as Department;
            txtDeptCode.Text = dept.Code;
            txtDeptName.Text =dept.Name;

        }
         void btnDeleteDept(object sender, RoutedEventArgs e)
        {
            Department dept = ((FrameworkElement)sender).DataContext as Department;
            this.DeleteDepts(dept.Id);

        }
    }
}
