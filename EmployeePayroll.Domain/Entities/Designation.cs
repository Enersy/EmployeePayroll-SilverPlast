using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Designation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DesignationCode { get; set; }
        public double Basic { get; set; }
       
    }
}
