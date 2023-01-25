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
         Task<EmpPieceRateSalaryDetails> GetPieceRateSalaryDetailss(int id);
        Task<HttpResponseMessage> DeletePieceRateSalaryDetailss(int Id);
        Task<HttpResponseMessage> UpdatePieceRateSalaryDetailss(EmpPieceRateSalaryDetails PieceRateSalaryDetailss);
        Task<IEnumerable<EmpPieceRateSalaryDetails>> GetPieceRateSalaryDetailsss();
        Task<HttpResponseMessage> SavePieceRateSalaryDetailss(EmpPieceRateSalaryDetails PieceRateSalaryDetailss);
    }
}
