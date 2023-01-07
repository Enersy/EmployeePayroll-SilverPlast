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
        public IAllowanceRepository Allowance {get; }

        public IAttendanceRepository Attendance {get;  }

        public IDeductionRepository Deduction {get; }

        public IEmpPieceRateRepository PieceRate {get;  }

        public IEmpWagerSalaryDetails EmpWagerSalaryDetails {get;  }
        public IDesignationRepository Designation { get; set; }

        public ISalaryDetailsRepository SalaryDetails {get;  }
        public IDepartmentRepository Department {get; }
        public ICategoryRepository Category { get; }

        public ILoanRepository Loan {get; set; }

        

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
