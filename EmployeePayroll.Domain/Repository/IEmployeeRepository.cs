using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
       Task< IEnumerable<Employee>> GetAllEmployees();
        Task UpdateEmployee(Employee employee);
        Task DeleteEmployee(int Id);
    }
}
