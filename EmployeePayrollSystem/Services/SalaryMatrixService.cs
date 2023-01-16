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
    public class SalaryMatrixService : ISalaryMatrixService
    {
        private HttpClient client;
        public SalaryMatrixService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("appliSalaryMaxion/json")
                );
        }
        public async Task<HttpResponseMessage> DeleteSalaryMax(int Id)
        {
           var response = await client.DeleteAsync("SalaryMatrix/" + Id);
            return response;
        }

        public async Task<SalaryMatrix> GetSalaryMax(int id)
        {
            var response = await client.GetStringAsync("SalaryMatrix/"+ id);
            return JsonConvert.DeserializeObject<SalaryMatrix>(response);
        }

        public async Task<IEnumerable<SalaryMatrix>> GetSalaryMaxs()
        {
            var response = await client.GetStringAsync("SalaryMatrix");
            return JsonConvert.DeserializeObject<IEnumerable<SalaryMatrix>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SaveSalaryMax(SalaryMatrix salaryMax)
        {
           var response = await client.PostAsJsonAsync("SalaryMatrix", salaryMax);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateSalaryMax(SalaryMatrix salaryMax)
        {
           var response = await client.PutAsJsonAsync("SalaryMatrix/" + salaryMax.Id, salaryMax);
            return response;
        }
    }
}
