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
        public async void DeleteSalaryMax(int Id)
        {
            await client.DeleteAsync("SalaryMatrix/" + Id);
        }

        public async Task<IEnumerable<SalaryMatrix>> GetSalaryMaxs()
        {
            var response = await client.GetStringAsync("SalaryMatrix");
            return JsonConvert.DeserializeObject<IEnumerable<SalaryMatrix>>(response).ToList();
        }

        public async void SaveSalaryMax(SalaryMatrix salaryMax)
        {
            await client.PostAsJsonAsync("SalaryMatrix", salaryMax);
        }

        public async void UpdateSalaryMax(SalaryMatrix salaryMax)
        {
            await client.PutAsJsonAsync("SalaryMatrix/" + salaryMax.Id, salaryMax);
        }
    }
}
