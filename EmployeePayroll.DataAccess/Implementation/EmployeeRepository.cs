using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess.Implementation
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository
    {
        private readonly EmployeePayrollDbContext _context;
        public EmployeeRepository(EmployeePayrollDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteEmployee(int Id)
        {
            var Emp = _context.Employees.Where(x => x.empId == Id).FirstOrDefault();
            _context.Employees.Remove(Emp);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return _context.Employees;
        }


        public async Task UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
