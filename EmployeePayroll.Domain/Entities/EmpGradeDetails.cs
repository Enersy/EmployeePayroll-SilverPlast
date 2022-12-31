using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    internal class EmpGradeDetails
    {
        public int TransactionId { get; set; }
        public int empId { get; set; }
        public int empDeptId { get; set; }
        public int empGradeId { get; set; }
        public DateTime empFromDate { get; set; }
        public string empToDate { get; set; }

    }
}
