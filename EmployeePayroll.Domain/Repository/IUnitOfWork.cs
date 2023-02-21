﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IAdminRepository Administrator { get; }
        ICashAdvanceRepository CashAdvance { get; }
        IAllowanceRepository Allowance { get;  }
        IAttendanceRepository Attendance { get; }
        IDeductionRepository Deduction { get; }
        IEmpPieceRateRepository PieceRate { get; }
        IEmpWagerSalaryDetailsRepository EmpWagerSalaryDetails { get; }
        ISalaryDetailsRepository SalaryDetails { get; }
        ILoanRepository Loan { get; }
        IDepartmentRepository Department { get; }
        ICategoryRepository Category { get; }
        ISalaryMatrixRepository SalaryMatrix { get; }
        IEmployeeRepository Employee { get; }

        int Save();
       
    }
}
