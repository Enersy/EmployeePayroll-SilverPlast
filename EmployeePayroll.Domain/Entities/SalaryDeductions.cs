using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class SalaryDeductions
    {
        public int Id { get; set; }
        public double SalaryPAYE { get; set; }
        public double SalaryLoanRepaid { get; set; }
        public double SalaryCashAdvance { get; set; }
        public double SalaryNPF { get; set; }
        public double SalaryUnionDues { get; set; }
        public double SalaryAbsenteeism { get; set; }
        public double SalarySpecialDeds { get; set; }
    }
}
