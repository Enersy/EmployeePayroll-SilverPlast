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
    /// Interaction logic for ucCategory.xaml
    /// </summary>
    public partial class ucCategory : UserControl
    {
        private CategoryService service;
        public ucCategory()
        {
            service = new CategoryService();
            InitializeComponent();
            Loaddata();
        }


        async void Loaddata()
        {
            dgCategoryDetails.CanUserAddRows = false;
            dgCategoryDetails.DataContext = await service.GetCat();
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
                await service.SaveCat(cat);
                //  MessageBox.Show("Catartment Saved Successfully");
                dgCategoryDetails.ItemsSource = await service.GetCat();
                dgCategoryDetails.Items.Refresh();
            }
            else
            {
                await service.UpdateCat(cat);
                // MessageBox.Show("Catartmenr Updated Successfully");
                dgCategoryDetails.ItemsSource = await service.GetCat();
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
            service.DeleteCat(cat.Id);


            dgCategoryDetails.ItemsSource = await service.GetCat();

            dgCategoryDetails.Items.Refresh();
        }
    }
}
