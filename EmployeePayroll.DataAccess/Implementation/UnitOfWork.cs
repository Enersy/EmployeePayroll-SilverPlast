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
    public class UnitOfWork : IUnitOfWork
    {
        public IAllowanceRepository Allowance {get; }

        public IAttendanceRepository Attendance {get;  }

        public IDeductionRepository Deduction {get; }

        public IEmpPieceRateRepository PieceRate {get;  }

        public IEmpWagerSalaryDetailsRepository EmpWagerSalaryDetails {get;  }
        public IDesignationRepository Designation { get; set; }

        public ISalaryDetailsRepository SalaryDetails {get;  }
        public IDepartmentRepository Department {get; }
        public ICategoryRepository Category { get; }

        public ILoanRepository Loan {get;  }

        public ISalaryMatrixRepository SalaryMatrix {get;}
        public IEmployeeRepository Employee { get; }

        public IAdminRepository Administrator { get; }

        public ICashAdvanceRepository CashAdvance { get; }

        private EmployeePayrollDbContext _context;
        public UnitOfWork(EmployeePayrollDbContext employeePayrollDbContext)
        {
            _context = employeePayrollDbContext;
            Attendance = new AttendanceRepository(_context);
            Allowance = new AllowanceRepository(_context);
            Designation = new DesignationRepository(_context);
            SalaryDetails = new SalaryDetailsRepository(_context);
            Department = new DepartmentRepository(_context);
            Category = new CategoryRepository(_context);
            SalaryMatrix = new SalaryMatrixRepository(_context);
            Employee = new EmployeeRepository(_context);
            EmpWagerSalaryDetails = new WagerSalaryDetailRepository(_context);
            PieceRate = new PieceRateSalaryDetailsRepository(_context);
            Loan = new LoanRepository(_context);
            Administrator = new AdminRepository(_context);
            CashAdvance = new CashAdvanceRepository(_context);



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
