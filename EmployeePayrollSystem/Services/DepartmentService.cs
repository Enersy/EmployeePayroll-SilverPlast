using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public class DepartmentService: IDepartmentService
    {
        private HttpClient client;
        public DepartmentService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

        }

        public async void SaveDepts(Department department)
        {
            await client.PostAsJsonAsync("Department", department);
        }

        public async Task<Department> GetDept(int Id)
        {
          var response = await client.GetStringAsync("Department/" + Id);
            var data = JsonConvert.DeserializeObject<Department>(response);
            return data;

        }

        public async void DeleteDepts(int Id)
        {
            await client.DeleteAsync("Department/" + Id);

        }

        public async void UpdateDepts(Department department)
        {
            await client.PutAsJsonAsync("Department/" + department.Id, department);

        }

        public async Task<IEnumerable<Department>> GetDepts()
        {
            var response = await client.GetStringAsync("Department");
            return JsonConvert.DeserializeObject<IEnumerable<Department>>(response).ToList();
        }

        
       
    }
}
