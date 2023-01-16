using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class EmpWagerSalaryDetails
    {
        [Key]
        public int TransactionId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime empSalaryYear { get; set; }
        public DateTime empSalaryPaidDate { get; set; }
        public double empBasic { get; set; }
        public double empTA { get; set; }
        public double empHRA { get; set; }
        public double empUtilityA { get; set; }
        public double empMA { get; set; }
        public double empBonus { get; set; }
        public double empTax { get; set; }
        public double empGross { get; set; }
        public double empTotalSalary { get; set; }
    }
}
