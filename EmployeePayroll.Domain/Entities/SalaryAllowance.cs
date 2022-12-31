using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class SalaryAllowance
    {
        public int Id { get; set; }
        public double SalaryMedAllowance { get; set; }
        public double SalaryTraFedAllowance { get; set; }
        public double SalaryHouseAllowance { get; set; }
        public double SalaryUtilityAllowance { get; set; }
        public double SalaryOvertimeAllowance { get; set; }
        public double SalaryMiscelenousAllowance { get; set; }
        public double SalarySpecialAllowance { get; set; }
    }
}
