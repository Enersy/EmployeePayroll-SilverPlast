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
    public class PieceRateSalaryDetailsRepository : GenericRepository<EmpPieceRateSalaryDetails>, IEmpPieceRateRepository
    {
        public PieceRateSalaryDetailsRepository(EmployeePayrollDbContext context) : base(context)
        {
            Context = context;
        }

        public EmployeePayrollDbContext Context { get; }
    }
}
