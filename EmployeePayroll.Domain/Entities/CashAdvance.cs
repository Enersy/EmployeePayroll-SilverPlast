using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    internal class CashAdvance
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }= string.Empty;
        public DateOnly DateCollected { get; set; }
        public double AdvanceAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public double InstallmentAmount { get; set; }
    }
}
