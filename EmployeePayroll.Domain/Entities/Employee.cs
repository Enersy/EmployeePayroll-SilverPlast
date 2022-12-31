using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Employee
    {
        public string emp_firstName { get; set; }
        public string emp_lastName { get; set; }

        public string emp_title { get; set; }
        public DateTime emp_dob { get; set; }
        public DateTime emp_job { get; set; }
        public string nextOfKin { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty ;
        public string Address { get; set; }
        public string  passport { get; set; }


    }
}
