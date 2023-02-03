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
    public partial class LoanViewModel
    {
       
        public int id;
        [ObservableProperty]
        public string empId;
        [ObservableProperty]
        public string empName;
        [ObservableProperty]
        public DateTime dateTaken;
        [ObservableProperty]
        public int installment;
        [ObservableProperty]
        public double loanAmount;
        [ObservableProperty]
        public double repaymentAmount;
        [ObservableProperty]
        public double loanBalance;
        [ObservableProperty]
        public ObservableCollection<Employee> empList;

        private EmployeeService _empService;
        private LoanService _loanService;
        [ObservableProperty]
        private ObservableCollection<Loan> loanList;

        public LoanViewModel()
        {
            _empService= new EmployeeService();
            _loanService = new LoanService();   
            loadLoan();
        }
        [RelayCommand]
        public async Task SaveLoan() 
        {
            var loan = new Loan();
            loan.DateTaken = DateTime.UtcNow.Date;
            loan.EmpId = EmpId;
            loan.EmpName=EmpName;
            loan.LoanAmount = LoanAmount;
            loan.LoanBalance = LoanBalance - LoanAmount;
            loan.RepaymentAmount= repaymentAmount;
            loan.Installments = Installment;

            var response = await _loanService.SaveLoan(loan);
            if (response.IsSuccessStatusCode)
            {
                LoanList.Add(loan);
                MessageBox.Show(" Your Loan was successful!", "Save Loan");
               
            }
        
        }
        public async Task loadLoan()
        {
          var data = await _loanService.GetLoans();
            LoanList = new ObservableCollection<Loan>(data);
        }
    }
}
