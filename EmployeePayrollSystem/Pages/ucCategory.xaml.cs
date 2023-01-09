using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EmployeePayrollSystem.Pages
{
    /// <summary>
    /// Interaction logic for ucCategory.xaml
    /// </summary>
    public partial class ucCategory : UserControl
    {
        private CategoryService _service;
        public ucCategory()
        {
            _service = new CategoryService();
            InitializeComponent();
            Loaddata();
        }


        async void Loaddata()
        {
            dgCategoryDetails.CanUserAddRows = false;
            dgCategoryDetails.DataContext = await _service.GetCats();
        }
        private async void Button_Save(object sender, RoutedEventArgs e)
        {

            var cat = new Category()
            {
                
                Name = txtCatName.Text,
                Id = Convert.ToInt32(txtCatId.Text)
            };

            if (cat.Id == 0)
            {
                 _service.SaveCat(cat);
                //  MessageBox.Show("Catartment Saved Successfully");
                dgCategoryDetails.ItemsSource = await _service.GetCats();
                dgCategoryDetails.Items.Refresh();
            }
            else
            {
                 _service.UpdateCat(cat);
                // MessageBox.Show("Catartmenr Updated Successfully");
                dgCategoryDetails.ItemsSource = await _service.GetCats();
                dgCategoryDetails.Items.Refresh();

            }

           
            txtCatName.Text = "";
           
        }

        private void btnEditCat(object sender, RoutedEventArgs e)
        {
            Category cat = ((FrameworkElement)sender).DataContext as Category;
            txtCatId.Text = cat.Id.ToString();
            txtCatName.Text = cat.Name;
        }

        private async void btnDeleteCat(object sender, RoutedEventArgs e)
        {
            Category cat = ((FrameworkElement)sender).DataContext as Category;
            _service.DeleteCat(cat.Id);


            dgCategoryDetails.ItemsSource = await _service.GetCats();

            dgCategoryDetails.Items.Refresh();
        }
    }
}
