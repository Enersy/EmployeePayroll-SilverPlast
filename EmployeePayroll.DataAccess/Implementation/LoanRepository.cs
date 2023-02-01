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
    public class LoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        private readonly EmployeePayrollDbContext context;

        public LoanRepository(EmployeePayrollDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
