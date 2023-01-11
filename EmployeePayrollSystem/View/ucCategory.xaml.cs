using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using EmployeePayrollSystem.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmployeePayrollSystem.View
{
    /// <summary>
    /// Interaction logic for ucCategory.xaml
    /// </summary>
    public partial class ucCategory : UserControl
    {
        private CategoryViewModel _categoryViewModel;
        public ucCategory()
        {
            
            _categoryViewModel = new CategoryViewModel();
            DataContext = _categoryViewModel;
         //   _categoryViewModel.loadData();
         //  dgCategoryDetails.ItemsSource = _categoryViewModel.CatList
            InitializeComponent();
            
        }


        //async void Loaddata()
        //{
        //    dgCategoryDetails.CanUserAddRows = false;
        //    dgCategoryDetails.ItemsSource = await _service.GetCats();
        //}


        private void btnEditCat(object sender, RoutedEventArgs e)
        {
            Category cat = ((FrameworkElement)sender).DataContext as Category;
            txtCatId.Text = cat.Id.ToString();
            txtCatName.Text = cat.Name;
        }

        private void btnDeleteCat(object sender, RoutedEventArgs e)
        {
            Category cat = ((FrameworkElement)sender).DataContext as Category;
            _categoryViewModel.DeleteCategory(cat.Id);
        }

        //private async void btnDeleteCat(object sender, RoutedEventArgs e)
        //{
        //    Category cat = ((FrameworkElement)sender).DataContext as Category;
        //    _service.DeleteCat(cat.Id);


        //    dgCategoryDetails.ItemsSource = await _service.GetCats();

        //    dgCategoryDetails.Items.Refresh();
        //}
    }
}
