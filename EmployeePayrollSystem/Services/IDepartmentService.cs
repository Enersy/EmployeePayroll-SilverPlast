using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepts();
        Task<Department> GetDept(int v);
        void UpdateDepts(Department response);
        void DeleteDepts(int id);
        void SaveDepts(Department response);
    }
}
