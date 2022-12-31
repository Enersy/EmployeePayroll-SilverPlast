using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }

    }
}
