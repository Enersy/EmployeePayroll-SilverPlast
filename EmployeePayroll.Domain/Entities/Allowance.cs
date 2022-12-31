using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Allowance
    {
        public int Id { get; set; }
        public SalaryAllowance salaryAllowance { get; set; }
        public WagersAllowance wagersAllowance { get; set; }
        public PieceRateAllowance pieceRateAllowance { get; set; }
    }
}
