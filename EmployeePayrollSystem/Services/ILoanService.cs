using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface ILoanService 
    {
        Task<Loan> GetLoan(int id);
        Task<IEnumerable<Loan>> GetLoans();
        Task<HttpResponseMessage> DeleteLoan(int Id);
        Task<HttpResponseMessage> UpdateLoan(Loan loan);
        Task<HttpResponseMessage> SaveLoan(Loan loan);
    }
}
