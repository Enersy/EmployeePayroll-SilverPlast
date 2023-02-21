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
       

    }
}
