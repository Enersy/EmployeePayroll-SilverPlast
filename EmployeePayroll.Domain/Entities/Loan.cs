using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Loan
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string  EmpName { get; set; }
        public DateTime DateTaken { get; set; }
        public DateTime DueDate { get; set; }
        public double LoanAmount { get; set; }
        public double RepaymentAmount { get; set; }
        public double LoanBalance { get; set; }

    }
}
