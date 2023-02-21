using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class WagersAllowance
    {
        public int Id { get; set; }
        public double WagersTraFedAllowance { get; set; }
        public double WagersHouseAllowance { get; set; }
        public double WagersOvertimeAllowance { get; set; }
        public double WagersMiscelenousAllowance { get; set; }
        public double WagersMedAllowance { get; set; }
        public double WagersSpecialAllowance { get; set; }
        public double WagersNightAllowance { get; set; }
    }
}
