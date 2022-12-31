using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAllowanceRepository Allowance {get; set; }

        public IAttendanceRepository Attendance {get; set; }

        public IDeductionRepository Deduction {get; set; }

        public IEmpPieceRateRepository PieceRate {get; set; }

        public IEmpWagerSalaryDetails EmpWagerSalaryDetails {get; set; }

        public ISalaryDetailsRepository SalaryDetails {get; set; }

        public ILoanRepository Loan {get; set; }
        private EmployeePayrollDbContext _context;
        public UnitOfWork(EmployeePayrollDbContext employeePayrollDbContext)
        {
            _context = employeePayrollDbContext;
        }
        public void Dispose()
        {
            
        }

        public  int Save()
        {
           return  _context.SaveChanges();
        }
    }
}
