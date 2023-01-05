using EmployeePayroll.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeePayrollSystem.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        public String txtDeptName;
        public String txtDeptCode;


        ICommand Save { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }
        public MainViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async void GetEmp() 
        {
           await _unitOfWork.Attendance.GetAll();
        }
    }
}
