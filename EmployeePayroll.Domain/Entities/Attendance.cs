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
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }
        public double TotalTime { get; set; }
        public double TotalHrs { get; set; }
        public string Shift { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
