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
    public partial class DepartmentViewModel
    {
        
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string code;
        [ObservableProperty]
        public string category;
        [ObservableProperty]
        public string description;

       
        public CategoryService Catservice;
        private readonly IDepartmentService _service;

       [ObservableProperty]
        private ObservableCollection<Department> deptlist;

        public int Id { get; set; }

      
        private Department _department;

        public DepartmentViewModel()
        {
            _service = new DepartmentService();
            _department = new Department();
            loadData();

        }

        [RelayCommand]
        private void SaveDept() 
        {
            _department.Name = Name;
            _department.Code = Code;
            _department.Category = Category;
            _department.Description = Description;

            if (_department.Id == 0)
            {
                _service.SaveDepts(_department);

                //  MessageBox.Show("Catartment Saved Successfully");
                loadData();
                ClearField();
                //  dgCategoryDetails.Items.Refresh();
            }
            else
            {
                _service.UpdateDepts(_department);
                // MessageBox.Show("Catartmenr Updated Successfully");


            }

        }

        private void ClearField()
        {
            Name = String.Empty;
            Code = String.Empty;
            Category = String.Empty;
            Description = String.Empty;
        }

        public async void loadData()
        {
           var depts = await  _service.GetDepts();
           Deptlist = new  ObservableCollection<Department>(depts);
        }
    }
}
