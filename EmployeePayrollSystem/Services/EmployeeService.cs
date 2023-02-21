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
    public class EmployeeService : IEmployeeService
    {
        private HttpClient client;
        public EmployeeService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        public async Task<HttpResponseMessage> DeleteEmployee(int Id)
        {
            var response = await client.DeleteAsync("Employee/" + Id);
            return response;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var response = await client.GetStringAsync("Employee/" + id);
            return JsonConvert.DeserializeObject<Employee>(response);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response = await client.GetStringAsync("Employee");
            return JsonConvert.DeserializeObject<IEnumerable<Employee>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SaveEmployee(Employee Employee)
        {
            var response = await client.PostAsJsonAsync("Employee", Employee);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateEmployee(Employee Employee)
        {
            var response = await client.PutAsJsonAsync("Employee/" + Employee.empId, Employee);
            return response;
        }
    }
}
