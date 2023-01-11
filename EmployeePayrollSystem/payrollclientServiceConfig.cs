using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem
{
    public class payrollclientServiceConfig
    {
        public HttpClient Client { get; }

        public payrollclientServiceConfig(HttpClient client)
        {
           
        }
    }
}
