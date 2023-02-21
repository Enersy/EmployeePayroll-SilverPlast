using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class WagersDeduction
    {
        public int Id { get; set; }
        public double WagersPAYE { get; set; }
        public double WagersLoanRepaid { get; set; }
        public double WagersCashAdvance { get; set; }
        public double WagersNPF { get; set; }
        public double WagersUnionDues { get; set; }
        public double WagersAbsenteeism { get; set; }
        public double WagersSpecialDeds { get; set; }
    }
}
