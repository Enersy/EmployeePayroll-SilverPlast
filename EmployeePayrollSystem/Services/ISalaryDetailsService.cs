using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public  interface ISalaryDetailsService
    {
        Task<EmpSalaryDetails> GetSalaryDtails(int id);
        Task<HttpResponseMessage> DeleteSalaryDtails(int Id);
        Task<HttpResponseMessage> UpdateSalaryDtails(EmpSalaryDetails SalaryDtails);
        Task<IEnumerable<EmpSalaryDetails>> GetSalaryDtailss();
        Task<HttpResponseMessage> SaveSalaryDtails(EmpSalaryDetails SalaryDtails);
    }
}
