using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.ViewModels;
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
        private SalaryMatrixViewModel matrixViewModel;

        public ucSalaryMatrix()
        {
            matrixViewModel = new SalaryMatrixViewModel();
            DataContext = matrixViewModel;
            departmentService = new DepartmentService();
            categoryService = new CategoryService();
            salaryMatrixService = new SalaryMatrixService();
           
            InitializeComponent();
        }

        private async void btnDeleteMatrix(object sender, RoutedEventArgs e)
        {
            try
            { 
                SalaryMatrix cat = ((FrameworkElement)sender).DataContext as SalaryMatrix;
                salaryMatrixService.DeleteSalaryMax(cat.Id);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Source.ToString(), ex.Message);
            }
        }

        private void btnEditMatrix(object sender, RoutedEventArgs e)
        {
            SalaryMatrix max = ((FrameworkElement)sender).DataContext as SalaryMatrix;
            matrixViewModel.Id = max.Id;
            matrixViewModel.BigMatRate = max.BigMatRate;
            matrixViewModel.BigMatRate = max.DayRate;
            matrixViewModel.HouseAllowanceRate = max.HouseAllowanceRate;
            matrixViewModel.DayRate = max.DayRate;
            matrixViewModel.HourlyRate = max.HourlyRate;
            matrixViewModel.SmallMatRate = max.SmallMatRate;
            matrixViewModel.TPFeedingAllowanceRate = max.TPFeedingAllowanceRate;
            matrixViewModel.UtilityAllowanceRate = max.UtilityAllowanceRate ;
            matrixViewModel.Category = max.Category;
            matrixViewModel.Department = max.Department;

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
