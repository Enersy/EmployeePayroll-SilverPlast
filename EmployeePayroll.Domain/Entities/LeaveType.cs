using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    internal class LeaveType
    {
        public int Id { get; set; }
        public string Name { get; set; }= String.Empty; 
        public int YealyLimit { get; set; }
        public int CarryForward { get; set; }
        public string ApplicableTo { get; set; } = String.Empty;
        public string ConsideredAs { get; set; } =String.Empty;
        public string Description { get; set; } = String.Empty ;
    }
}
