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
    public partial class SalaryMatrixViewModel
    {
        [ObservableProperty]
        public int id;
        [ObservableProperty]
        public double houseAllowanceRate;
        [ObservableProperty]
        public double tPFeedingAllowanceRate;
        [ObservableProperty]
        public double smallMatRate;
        [ObservableProperty]
        public double bigMatRate;
        [ObservableProperty]
        public double dayRate;
        [ObservableProperty]
        public double hourlyRate;
        [ObservableProperty]
        public double utilityAllowanceRate;
        [ObservableProperty]
        public string category;
        [ObservableProperty]
        public string department;

        private readonly ISalaryMatrixService _service;
        [ObservableProperty]
        public ObservableCollection<SalaryMatrix> matList;

        public SalaryMatrixViewModel()
        {
            _service=new SalaryMatrixService();
            loadData();
        }

        [RelayCommand]
        private async void SaveSalaryMax() 
        {

            SalaryMatrix mat = new SalaryMatrix();
            mat.Id = id;
            mat.Department = Department;
            mat.HouseAllowanceRate = HouseAllowanceRate;
            mat.DayRate = DayRate;
            mat.SmallMatRate = SmallMatRate;
            mat.BigMatRate = BigMatRate;
            mat.UtilityAllowanceRate = UtilityAllowanceRate;
            mat.HourlyRate = HourlyRate;
            mat.Category = Category;
            mat.TPFeedingAllowanceRate = TPFeedingAllowanceRate;


            try
            {
                if (mat.Id == 0)

                {
                    var response = await _service.SaveSalaryMax(mat);

                    //  MessageBox.Show("matartment Saved Successfully");
                    if (response.IsSuccessStatusCode)
                    {
                        MatList.Add(mat);
                    }

                }
                else
                {
                    var response = await _service.UpdateSalaryMax(mat);
                    if (response.IsSuccessStatusCode)
                    {

                        loadData();
                    }

                    // MessageBox.Show("matartmenr Updated Successfully");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save Operation");
            }

            ClearField();


        }

        private void ClearField()
        {
            BigMatRate = 0;
            DayRate = 0;
            Category = "";
            Department = "";
            SmallMatRate = 0;
            Id = 0;
            HouseAllowanceRate = 0;
            HourlyRate = 0;
            TPFeedingAllowanceRate = 0;
            UtilityAllowanceRate = 0;
        }

         async void loadData()
        {
            var salaryMatrices = await _service.GetSalaryMaxs();

            MatList = new ObservableCollection<SalaryMatrix>(salaryMatrices.ToList());
             
        }
    }
}
