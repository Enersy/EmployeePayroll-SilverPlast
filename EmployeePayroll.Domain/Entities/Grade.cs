using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Grade
    {
        public int gradeId { get; set; }
        public string gradeName { get; set; }
        public string gradeShortName { get; set; }
        public double grade_basic { get; set; }
        public double gradeTA { get; set; }
        public double gradeHRA { get; set; }
        public double gradeMA { get; set; }
        public double gradeBonus { get; set; }

    }
}
