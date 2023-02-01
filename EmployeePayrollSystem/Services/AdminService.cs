using EmployeePayroll.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public class AdminService : IAdminService
    {
        private HttpClient client;
        public AdminService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

        }
        public async Task<HttpResponseMessage> DeleteAdmin(int Id)
        {
            var response = await client.DeleteAsync("Admin/" + Id);
            return response;
        }

        public async Task<Admin> GetAdmin(int id)
        {
            var response = await client.GetStringAsync("Admin/" + id);
            return JsonConvert.DeserializeObject<Admin>(response);
        }

        public async Task<IEnumerable<Admin>> GetAdmins()
        {
            var response = await client.GetStringAsync("Admin");
            return JsonConvert.DeserializeObject<IEnumerable<Admin>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SaveAdmin(Admin admin)
        {
            var response = await client.PostAsJsonAsync("Admin", admin);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateAdmin(Admin admin)
        {
            var response = await client.PutAsJsonAsync("Admin/" + admin.id, admin);
            return response;
        }
    }
}
