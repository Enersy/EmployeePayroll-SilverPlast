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
        Task<EmpSalaryDetails> GetSalaryDetails(int id);
        Task<HttpResponseMessage> DeleteSalaryDetails(int Id);
        Task<HttpResponseMessage> UpdateSalaryDetails(EmpSalaryDetails SalaryDtails);
        Task<IEnumerable<EmpSalaryDetails>> GetSalaryDetails();
        Task<HttpResponseMessage> SaveSalaryDetails(EmpSalaryDetails SalaryDtails);
    }
}
