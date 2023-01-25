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

       
    }
}
