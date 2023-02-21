using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface ICashAdvanceService
    {
        Task<CashAdvance> GetCashAdvance(int id);
        Task<IEnumerable<CashAdvance>> GetCashAdvance();
        Task<HttpResponseMessage> DeleteCashAdvance(int Id);
        Task<HttpResponseMessage> UpdateCashAdvance(CashAdvance cashAdvance);
        Task<HttpResponseMessage> SaveCashAdvance(CashAdvance cashAdvance);
    }
}
