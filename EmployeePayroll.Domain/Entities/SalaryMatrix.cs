using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class SalaryMatrix
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public double DayRate { get; set; }
        public double HourlyRate { get; set; }
        public double CashAdvance { get; set; }
        public double SmallMatRate { get; set; }
        public double BigMatRate { get; set; }
        public double HouseAllowanceRate { get; set; }
        public double TPFeedingAllowanceRate { get; set; }
        public double NightAllowanceRate { get; set; }
        public double UtilityAllowanceRate { get; set; }

        public string Currency { get; set; } = string.Empty;

    }
}
