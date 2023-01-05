using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface IUnitOfWork:IDisposable
    {
        IAllowanceRepository Allowance { get;  }
        IAttendanceRepository Attendance { get; }
        IDeductionRepository Deduction { get; }
        IEmpPieceRateRepository PieceRate { get; }
        IEmpWagerSalaryDetails EmpWagerSalaryDetails { get; }
        ISalaryDetailsRepository SalaryDetails { get; }
        ILoanRepository Loan { get; }
        IDepartmentRepository Department { get; }

        int Save();
       
    }
}
