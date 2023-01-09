using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;


namespace EmployeePayroll.DataAccess.Implementation
{
    public class SalaryMatrixRepository : GenericRepository<SalaryMatrix>, ISalaryMatrixRepository
    {
        private readonly EmployeePayrollDbContext _context;
        public SalaryMatrixRepository(EmployeePayrollDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<SalaryMatrix> GetAllSalaryMatrix()
        {
            return _context.salaryMatrices;
        }

        public void UpdateSalaryMatrix(SalaryMatrix matrix)
        {
            _context.salaryMatrices.Update(matrix);
        }

        public async void DeleteSalaryMatrix(int Id)
        {
            var dept = _context.salaryMatrices.Where(x => x.Id == Id).FirstOrDefault();
            _context.salaryMatrices.Remove(dept);
        }
    }
}
