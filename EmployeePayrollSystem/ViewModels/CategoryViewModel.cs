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
using System.Windows;

namespace EmployeePayrollSystem.ViewModels
{
    [ObservableObject]
    public partial class CategoryViewModel 
    {
        [ObservableProperty]
        private string catName;

        [ObservableProperty]
        private ObservableCollection<Category> catList;

        [ObservableProperty]
        private int id;

        
        private readonly ICategoryService _service;
        public CategoryViewModel()
        {
            _service = new CategoryService();
            loadData();
        }

       
        [RelayCommand]
        private async void SaveCategories ()
        {
            Category cat = new Category();
            cat.Name = catName;
            cat.Id = id;

            try
            {
                if (cat.Id == 0)

                {
                    var response = await _service.SaveCat(cat);

                    //  MessageBox.Show("Catartment Saved Successfully");
                    if (response.IsSuccessStatusCode)
                    {
                        CatList.Add(cat);
                    }

                }
                else
                {
                    var response = await _service.UpdateCat(cat);
                    if (response.IsSuccessStatusCode)
                    {
                       
                       loadData();
                    }

                    // MessageBox.Show("Catartmenr Updated Successfully");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Operation");
            }
    
                ClearField();

        }

        
        public async void DeleteCategory(int Id) 
        {
           var response = await _service.DeleteCat(Id);
            if (response.IsSuccessStatusCode)
            {
                loadData();
            }
           
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
