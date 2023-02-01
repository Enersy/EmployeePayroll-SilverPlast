using EmployeePayroll.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public class AttendanceService : IAttendanceService
    {
        private HttpClient client;
        public AttendanceService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        public async Task<HttpResponseMessage> SaveAttendance(Attendance attendance)
        {
            var response = await client.PostAsJsonAsync("Attendance", attendance);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAttendance(int Id)
        {
            var response = await client.DeleteAsync("Attendance/" + Id);
            return response;

        }

        public async Task<HttpResponseMessage> UpdateAttenedance(Attendance Attendance)
        {
            var response = await client.PutAsJsonAsync("Attendance/" + Attendance.Id, Attendance);
            return response;

        }

        public async Task<IEnumerable<Attendance>> GetAttencdances()
        {
            var response = await client.GetStringAsync("Attendance");
            return JsonConvert.DeserializeObject<IEnumerable<Attendance>>(response).ToList();

        }

        public async Task<Attendance> GetAttendance(int id)
        {
            var response = await client.GetStringAsync("Attendance/" + id);

            return JsonConvert.DeserializeObject<Attendance>(response);
        }
    }
}
