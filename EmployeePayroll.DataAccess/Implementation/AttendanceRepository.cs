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
   
        public class AttendanceRepository : GenericRepository<Attendance>, IAttendanceRepository
        {
            public AttendanceRepository(EmployeePayrollDbContext context) : base(context)
            {
            }

            public override async Task<IEnumerable<Attendance>> GetAll()
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
                    var exist = await dbSet.Where(x => x.Id == id)
                        .FirstOrDefaultAsync();
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

