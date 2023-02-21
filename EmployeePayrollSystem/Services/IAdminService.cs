using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface IAdminService
    {
        Task<Admin> GetAdmin(int id);
        Task<IEnumerable<Admin>> GetAdmins();
        Task<HttpResponseMessage> DeleteAdmin(int Id);
        Task<HttpResponseMessage> UpdateAdmin(Admin admin);
        Task<HttpResponseMessage> SaveAdmin(Admin admin);
    }
}
