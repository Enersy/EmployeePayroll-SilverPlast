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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly EmployeePayrollDbContext _context;
        public DepartmentRepository(EmployeePayrollDbContext context) : base(context)
        {
            _context = context;
        }

        public  IEnumerable<Department> GetAllDepartments()
        {
            return _context.Departments;
        }
    }
}
