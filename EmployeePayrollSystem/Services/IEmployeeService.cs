using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployee(int id);
        Task<IEnumerable<Employee>> GetEmployees();
        Task<HttpResponseMessage> DeleteEmployee(int Id);
        Task<HttpResponseMessage> UpdateEmployee(Employee Employee);
        Task<HttpResponseMessage> SaveEmployee(Employee Employee);
    }
}
