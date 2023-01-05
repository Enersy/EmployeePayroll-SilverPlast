using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess.Implementation
{
    public class AllowanceRepository : GenericRepository<Allowance>, IAllowanceRepository
    {
        public AllowanceRepository(EmployeePayrollDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Allowance>> GetAll()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override async Task<bool> Delete(int id) 
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (exist == null) return false;
                dbSet.Remove(exist);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
