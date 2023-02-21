using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class PieceRateDeduction
    {
        public int Id { get; set; }
        public double PieceRatePAYE { get; set; }
        public double PieceRateLoanRepaid { get; set; }
        public double PieceRateCashAdvance { get; set; }
        public double PieceRateNPF { get; set; }
        public double PieceRateUnionDues { get; set; }
        public double PieceRateAbsenteeism { get; set; }
        public double PieceRateSpecialDeds { get; set; }
    }
}
