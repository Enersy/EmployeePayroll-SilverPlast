using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class PieceRateAllowance
    {
        public int Id { get; set; }
        public double PieceRateTraFedAllowance { get; set; }
        public double PieceRateHouseAllowance { get; set; }
        public double PieceRateOvertimeAllowance { get; set; }
        public double PieceRateMiscelenousAllowance { get; set; }
        public double PieceRateMedAllowance { get; set; }
        public double PieceRateSpecialAllowance { get; set; }
        public double PieceRateNightAllowance { get; set; }
    }
}
