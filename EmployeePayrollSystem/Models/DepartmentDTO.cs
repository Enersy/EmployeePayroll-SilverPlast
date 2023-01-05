using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Models
{
    public class DepartmentDTO : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _deptName;

        public string DeptName
        {
            get { return _deptName; }
            set
            {
                _deptName = value;
                OnPropertyChanged("DeptName");
            }
        }
        private string _deptCode;

        public string DeptCode
        {
            get { return _deptCode; }
            set
            {
                _deptName = value;
                OnPropertyChanged("DeptCode");
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
