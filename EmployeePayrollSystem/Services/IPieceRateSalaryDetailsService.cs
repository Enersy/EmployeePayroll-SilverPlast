using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface IEmpPieceRateSalaryDetailsService
    {
         Task<EmpPieceRateSalaryDetails> GetPieceRateSalaryDetails(int id);
        Task<HttpResponseMessage> DeletePieceRateSalaryDetails(int Id);
        Task<HttpResponseMessage> UpdatePieceRateSalaryDetails(EmpPieceRateSalaryDetails PieceRateSalaryDetailss);
        Task<IEnumerable<EmpPieceRateSalaryDetails>> GetPieceRateSalaryDetails();
        Task<HttpResponseMessage> SavePieceRateSalaryDetails(EmpPieceRateSalaryDetails PieceRateSalaryDetailss);
    }
}
