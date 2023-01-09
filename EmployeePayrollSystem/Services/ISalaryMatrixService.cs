using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface ISalaryMatrixService
    {
        void DeleteSalaryMax(int Id);
        void UpdateSalaryMax(SalaryMatrix salaryMax);
        Task<IEnumerable<SalaryMatrix>> GetSalaryMaxs();
        void SaveSalaryMax(SalaryMatrix salaryMax);
    }
}
