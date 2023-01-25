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

          
        public async Task<IEnumerable<Attendance>> GetAllAttendance()
        {
            try
            {
                return await _context.Attendances.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task AddAttendance(Attendance attendances)
        {
           await _context.AddRangeAsync(attendances);    
            _context.SaveChanges();
        }

        public  async Task UpdateAttendance(Attendance attendance)
        {
             _context.Attendances.Update(attendance);
            _context.SaveChanges();

        }

        public async Task DeleteAttendance(int Id)
        {
            var Cat = _context.Attendances.Where(x => x.Id == Id).FirstOrDefault();

            if (Cat != null) 
            {
                _context.Attendances.Remove(Cat);
            }
         

        }
    }
    
}

