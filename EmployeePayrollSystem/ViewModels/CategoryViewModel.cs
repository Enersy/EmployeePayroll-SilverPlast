using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class CategoryViewModel 
    {
        [ObservableProperty]
        private string? catName;

        [ObservableProperty]
        private ObservableCollection<Category> catList;

        [ObservableProperty]
        private int id;

        private Category cat;
       


        private readonly ICategoryService _service;
        public CategoryViewModel()
        {
            cat = new Category()
            {
                Id =Convert.ToInt32( id),
                Name = catName,
            };
            _service = new CategoryService();

            loadData();
          
        }
       

        [RelayCommand]
        private void SaveCategories ()
        {


            if (cat.Id == 0)
            {
                _service.SaveCat(cat);

                //  MessageBox.Show("Catartment Saved Successfully");
                loadData();
                ClearField();
                //  dgCategoryDetails.Items.Refresh();
            }
            else
            {
                 _service.UpdateCat(cat);
                // MessageBox.Show("Catartmenr Updated Successfully");


            }

        }

        
        public async void DeleteCategory(int Id) 
        {
            _service.DeleteCat(Id);
            loadData();
        }

        [RelayCommand]
        private async void EditCategory() 
        {
           var dept = await _service.GetCategory(Id);
            if (dept != null) 
            {
                CatName = dept.Name;
                id = dept.Id;
            }
            
        }


        void ClearField() 
        {
            this.id = 0;
            this.CatName = String.Empty;
        }




        public  async void loadData()
        {
            var categories = await  _service.GetCats();

            CatList = new ObservableCollection<Category>( categories.ToList()); 
        }  
    }
}
