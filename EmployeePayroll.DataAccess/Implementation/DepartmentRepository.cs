using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;

namespace EmployeePayroll.DataAccess.Implementation
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly EmployeePayrollDbContext _context;
        public DepartmentRepository(EmployeePayrollDbContext context) : base(context)
        {
            _context = context;
        }

        public async  Task<IEnumerable<Department>> GetAllDepartments()
        {
            return _context.Departments;
        }

        public async Task UpdateDepartment(Department department)
        {
             _context.Departments.Update(department);   
        }

        public async Task DeleteDepartment(int Id)
        {
           var dept = _context.Departments.Where(x=>x.Id == Id).FirstOrDefault();
            _context.Departments.Remove(dept);
        }
    }
}
