using EmployeePayroll.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess
{
    internal class DesignTimeDbContextOptionFactory:IDesignTimeDbContextFactory<EmployeePayrollDbContext>
    {
        public EmployeePayrollDbContext CreateDbContext(string[] args) 
        {
            var options = new DbContextOptionsBuilder<EmployeePayrollDbContext>();
               options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = PayrollDb; Trusted_Connection = True; ");
            return new EmployeePayrollDbContext(options.Options);
        }
    }
}
