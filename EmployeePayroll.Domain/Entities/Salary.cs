using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Salary
    {
        public string empId { get; set; } = string.Empty;
        public double salaryAdvance { get; set; }
        public double salaryDeductions { get; set; }
        public double grossSalary { get; set; }
        public double  loanAmountToDeduct { get; set; }

    }
}
