using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
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
    /// Interaction logic for ucSalaryMatrix.xaml
    /// </summary>
    public partial class ucSalaryMatrix : UserControl
    {
        private DepartmentService departmentService;
        private CategoryService categoryService;
        private SalaryMatrixService salaryMatrixService;

        public ucSalaryMatrix()
        {
            departmentService = new DepartmentService();
            categoryService = new CategoryService();
            salaryMatrixService = new SalaryMatrixService();
            InitializeComponent();
        }

        private void btnDeleteMatrix(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditMatrix(object sender, RoutedEventArgs e)
        {

        }

        private async void Btn_SaveMatrix(object sender, RoutedEventArgs e)
        {
            var salaryMat = new SalaryMatrix()
            {
                BigMatRate = Convert.ToDouble(txtBigMatRate.Text),
                DayRate = Convert.ToDouble(txtBasicRate.Text),
                Category = cboCategory.Text,
                Department = cboDepartment.Text,
                SmallMatRate = Convert.ToInt32(txtSmallMatRate.Text)
            };

            if (salaryMat.Id == 0)
            {
                 salaryMatrixService.SaveSalaryMax(salaryMat);
                //  MessageBox.Show("Department Saved Successfully");

                dgDeptDetails.ItemsSource = await salaryMatrixService.GetSalaryMaxs();
                dgDeptDetails.Items.Refresh();
            }
            else
            {
                salaryMatrixService.UpdateSalaryMax(salaryMat);
                // MessageBox.Show("Departmenr Updated Successfully");

                dgDeptDetails.ItemsSource = await salaryMatrixService.GetSalaryMaxs();
                dgDeptDetails.Items.Refresh();

            }

            txtBigMatRate.Text = "";
            txtBasicRate.Text = "";
            cboCategory.Text = "";
             cboDepartment.Text = "";
            txtSmallMatRate.Text = "";

        }

        private async void cboDepartment_Initialized(object sender, EventArgs e)
        {
            try
            {
                var combodata = await departmentService.GetDepts();
                if (combodata != null)
                {
                    foreach (var item in combodata)
                    {
                        cboDepartment.Items.Add(item.Name);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private async void cboCategory_Initialized(object sender, EventArgs e)
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
    }
}
