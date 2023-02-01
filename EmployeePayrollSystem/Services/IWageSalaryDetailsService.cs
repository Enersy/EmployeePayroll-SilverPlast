using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface IWageSalaryDetailsService
    {
        Task<EmpWagerSalaryDetails> GetPieceRateSalaryDetails(int id);
        Task<HttpResponseMessage> DeletePieceRateSalaryDetails(int Id);
        Task<HttpResponseMessage> UpdatePieceRateSalaryDetails(EmpWagerSalaryDetails PieceRateSalaryDetailss);
        Task<IEnumerable<EmpWagerSalaryDetails>> GetPieceRateSalaryDetails();
        Task<HttpResponseMessage> SavePieceRateSalaryDetails(EmpWagerSalaryDetails PieceRateSalaryDetailss);

    }
}
