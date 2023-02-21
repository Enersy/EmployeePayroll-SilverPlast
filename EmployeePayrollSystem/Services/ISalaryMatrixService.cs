using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface ISalaryMatrixService
    {
        Task<SalaryMatrix> GetSalaryMax(int id);
        Task<HttpResponseMessage> DeleteSalaryMax(int Id);
        Task<HttpResponseMessage> UpdateSalaryMax(SalaryMatrix salaryMax);
        Task<IEnumerable<SalaryMatrix>> GetSalaryMaxs();
        Task<HttpResponseMessage> SaveSalaryMax(SalaryMatrix salaryMax);
    }
}
