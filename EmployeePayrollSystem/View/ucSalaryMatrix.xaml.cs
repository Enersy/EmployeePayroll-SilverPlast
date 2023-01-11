using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using System;
using System.Windows;
using System.Windows.Controls;



namespace EmployeePayrollSystem.View
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
            Loaddata();
        }

        private async void btnDeleteMatrix(object sender, RoutedEventArgs e)
        {
            try
            {

                SalaryMatrix cat = ((FrameworkElement)sender).DataContext as SalaryMatrix;
                salaryMatrixService.DeleteSalaryMax(cat.Id);
                dgMatDetails.Items.Remove(cat);


                dgMatDetails.ItemsSource = await salaryMatrixService.GetSalaryMaxs();
                


                dgMatDetails.Items.Refresh();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Source.ToString(), ex.Message);
            }
        }

        private void btnEditMatrix(object sender, RoutedEventArgs e)
        {
            SalaryMatrix max = ((FrameworkElement)sender).DataContext as SalaryMatrix;
            txtMatId.Text = max.Id.ToString();
            txtBigMatRate.Text = max.BigMatRate.ToString();
            txtDayRate.Text = max.DayRate.ToString();
            txtHouseAllowanceRate.Text = max.HouseAllowanceRate.ToString();
            txtNightAllowaRate.Text = max.NightAllowanceRate.ToString();
            txtSmallMatRate.Text = max.SmallMatRate.ToString();
            txtTpFeedingRate.Text = max.TPFeedingAllowanceRate.ToString();
            txtUtilityAllowanceRate.Text = max.UtilityAllowanceRate.ToString() ;
            cboCategory.Text = max.Category.ToString();
            cboDepartment.Text = max.Department.ToString();

        }

        async void Loaddata()
        {
            dgMatDetails.CanUserAddRows = false;
            dgMatDetails.ItemsSource = await salaryMatrixService.GetSalaryMaxs();
        }

        private async void Btn_SaveMatrix(object sender, RoutedEventArgs e)
        {
            try
            {

                var salaryMat = new SalaryMatrix()
                {
                    BigMatRate = Convert.ToDouble(txtBigMatRate.Text),
                    DayRate = Convert.ToDouble(txtDayRate.Text),
                    Category = cboCategory.Text,
                    Department = cboDepartment.Text,
                    SmallMatRate = Convert.ToDouble(txtSmallMatRate.Text),
                    Id = Convert.ToInt32(txtMatId.Text),
                    HouseAllowanceRate = Convert.ToInt32(txtHouseAllowanceRate.Text),
                    NightAllowanceRate = Convert.ToDouble(txtNightAllowaRate.Text),
                    TPFeedingAllowanceRate = Convert.ToDouble(txtTpFeedingRate.Text),
                    UtilityAllowanceRate = Convert.ToDouble(txtUtilityAllowanceRate.Text),

                };

                if (salaryMat.Id == 0)
                {
                    salaryMatrixService.SaveSalaryMax(salaryMat);
                    //  MessageBox.Show("Department Saved Successfully");

                    dgMatDetails.ItemsSource = await salaryMatrixService.GetSalaryMaxs();
                    dgMatDetails.Items.Refresh();
                }
                else
                {
                    salaryMatrixService.UpdateSalaryMax(salaryMat);
                    // MessageBox.Show("Departmenr Updated Successfully");

                    dgMatDetails.ItemsSource = await salaryMatrixService.GetSalaryMaxs();
                    dgMatDetails.Items.Refresh();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ToString(), ex.Message);
            }

            txtBigMatRate.Text = "";
            txtDayRate.Text = "";
            cboCategory.Text = "";
            cboDepartment.Text = "";
            txtSmallMatRate.Text = "";
            txtMatId.Text = "0";
            txtHouseAllowanceRate.Text = "";
            txtNightAllowaRate.Text = "";
            txtTpFeedingRate.Text = "";
            txtUtilityAllowanceRate.Text = "";

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

                MessageBox.Show(ex.Source.ToString(), ex.Message);
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

                MessageBox.Show(ex.Source.ToString(), ex.Message);
            }
        }
    }
}
