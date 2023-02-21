using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
        Task<IEnumerable<Department>> GetAllDepartments();
        Task UpdateDepartment(Department department);
        Task DeleteDepartment (int Id);
    }
}
