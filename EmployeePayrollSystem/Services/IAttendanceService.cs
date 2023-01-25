using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface IAttendanceService
    {
        Task<HttpResponseMessage> SaveAttendance(Attendance Attendance);
        Task<HttpResponseMessage> DeleteAttendance(int Id);
        Task<HttpResponseMessage> UpdateAttenedance(Attendance Attendance);
        Task<IEnumerable<Attendance>> GetAttencdances();
        Task<Attendance> GetAttendance(int id);
    }
}
