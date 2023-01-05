
using EmployeePayroll.Domain.Repository;
using EmployeePayrollSystem.Commands;
using EmployeePayroll.Domain.Entities;
using EmployeePayrollSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DepartmentDTO = EmployeePayrollSystem.Models.DepartmentDTO;

namespace EmployeePayrollSystem.ViewModels
{
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        public IUnitOfWork _unitOfWork;
        private Department dept;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand SaveCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public DepartmentViewModel()
        {
            //_departmentViewModel = departmentViewModel; 
             // _departmentDTO = new DepartmentDTO();
            Department dept = new Department();
            _departments = new ObservableCollection<DepartmentDTO>();
            SaveCommand = new Command(SaveExecute, CanSaveExecute);
            EditCommand = new Command(EditExecute, EditCanExecute);
            DeleteCommand = new Command(DeleteExecute, DeleteCanExecute);
        }

        private DepartmentDTO _departmentDTO;

        
        public DepartmentDTO Department
        {
            get { return _departmentDTO; }
            set { 
                _departmentDTO = value;
                OnPropertyChanged("Department");
            }
        }

        private ObservableCollection<DepartmentDTO> _departments;

        public ObservableCollection<DepartmentDTO> Departments
        {
            get { return _departments; }
            set { 
                _departments = value;
                OnPropertyChanged("Departments");
            }
        }



       

        private bool DeleteCanExecute(object arg)
        {
            return true;
        }

        private void DeleteExecute(object obj)
        {
            MessageBox.Show("Delete Command");
        }

        private bool EditCanExecute(object param)
        {
            return false;
        }

        public void EditExecute(object param)
        {
            MessageBox.Show("Edit Command");
        }

      

        public bool CanSaveExecute(object param) 
        {
            //if (string.IsNullOrEmpty(department?.Name) || string.IsNullOrEmpty(department.Code))
            //{
            //    return false;
            //}
            //else 
            //{
            //    return true;
            //}

            return true;
        }


        public async void SaveExecute(object param)
        {
            try
            {
               
                dept.Name = _departmentDTO.DeptName;
                dept.Code = _departmentDTO.DeptCode;
                var status = await _unitOfWork.Department.Add(dept);
                _unitOfWork.Save();
                if (status)
                {
                    Departments.Add(_departmentDTO);
                    MessageBox.Show("Department Save Successfully");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Something Went wrong", e.Message);
            }
        }

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(p));
        }

    }
}
