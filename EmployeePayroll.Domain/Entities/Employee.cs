using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string empCode { get; set; } = string.Empty;
        public string empFirstName { get; set; } = string.Empty;
        public string empLastName { get; set; } = string.Empty;
        public string empTitle { get; set; } = string.Empty;
        public string empCategory{ get; set; } = string.Empty;
        public DateTime empDob { get; set; }
        public DateTime empJob { get; set; }
        public string nextOfKin { get; set; } = string.Empty;
        public string phoneNumber { get; set; } = string.Empty ;
        public string Address { get; set; } = string.Empty;
        public string  passport { get; set; } = string.Empty;
        public string accountNumber { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;



    }
}
