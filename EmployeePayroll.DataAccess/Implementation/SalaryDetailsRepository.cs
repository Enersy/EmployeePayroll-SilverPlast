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
    public class SalaryDetailsRepository : GenericRepository<EmpSalaryDetails>, ISalaryDetailsRepository
    {
        public EmployeePayrollDbContext Context { get; }

        public SalaryDetailsRepository(EmployeePayrollDbContext context) : base(context)
        {
            Context = context;
        }

        //public async Task<IEnumerable<EmpSalaryDetails>> GetEmpSchedule(string EmpCode)
        //{
        //    var schedule = Context.Employees.Where(x=>x.empCode == EmpCode)
        //        .Include(i=> i.empCategory)
        //        .Include(a=>a.Attendances)
        //        .Include(d=>d.empTitle)
        //        .ToListAsync();

        //    return (IEnumerable<EmpSalaryDetails>)schedule;


        //}


    }
}
