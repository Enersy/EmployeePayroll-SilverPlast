﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Entities
{
    public class Admin
    {
        public int id { get; set; }
        public string username { get; set; }
        public string EmpName { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        
    }
}
