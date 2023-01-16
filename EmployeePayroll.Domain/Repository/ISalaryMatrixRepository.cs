using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface ISalaryMatrixRepository:IGenericRepository<SalaryMatrix>
    {
        Task<IEnumerable<SalaryMatrix>> GetAllSalaryMatrix();
        Task UpdateSalaryMatrix(SalaryMatrix salaryMatrix);
        Task DeleteSalaryMatrix(int Id);
    }
}
