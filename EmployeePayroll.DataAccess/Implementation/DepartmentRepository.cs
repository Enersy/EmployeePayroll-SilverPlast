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

        public void UpdateDepartment(Department department)
        {
             _context.Departments.Update(department);   
        }

        public async void DeleteDepartment(int Id)
        {
           var dept = _context.Departments.Where(x=>x.Id == Id).FirstOrDefault();
            _context.Departments.Remove(dept);
        }
    }
}
