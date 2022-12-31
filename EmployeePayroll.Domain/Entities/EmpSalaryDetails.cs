using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class EmpSalaryDetails
    {
        [Key]
        public int TransactionId { get; set; }
        public int EmployeeId { get; set; }
        public string empSalaryMonth { get; set; }
        public string empSalaryYear { get; set; }
        public DateOnly empSalaryPaidDate { get; set; }
        public int empDeptId { get; set; }
        public int  empGradeId { get; set; }
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
