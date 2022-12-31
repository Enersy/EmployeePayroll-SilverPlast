using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Deductions
    {
        public int Id { get; set; }
        public SalaryDeductions salaryDeductions { get; set; }
        public WagersDeduction wagersDeductions { get; set; }
        public PieceRateDeduction pieceRateDeductions { get; set; }


    }
}
