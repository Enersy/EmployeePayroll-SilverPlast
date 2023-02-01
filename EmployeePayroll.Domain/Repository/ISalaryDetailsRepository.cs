﻿using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface ISalaryDetailsRepository:IGenericRepository<EmpSalaryDetails>
    {
        //Task<IEnumerable<EmpSalaryDetails>> GetEmpSchedule(string EmpCode);
    }
}
