using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using EmployeePayrollSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeePayrollSystem.Commands
{
    public class Command : ICommand
    {
        private Action<object> executeMethod { get; set; }
        private Func<object, bool> canExecuteMethod { get; set; }

       
        public Command(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }
        public event EventHandler CanExecuteChanged;
       

        public bool CanExecute(object? parameter)
        {
            return canExecuteMethod(parameter);
        }

        public async void Execute(object? parameter)
        {
            this.executeMethod(parameter);
              
           
        }
    }
}
