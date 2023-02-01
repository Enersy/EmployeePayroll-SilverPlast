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
    public class SalaryDetailsService : ISalaryDetailsService
    {
        private HttpClient client;
        public SalaryDetailsService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        public async Task<HttpResponseMessage> DeleteSalaryDetails(int Id)
        {
            var response = await client.DeleteAsync("EmpSalaryDetails/" + Id);
            return response;
        }

        public async Task<EmpSalaryDetails> GetSalaryDetails(int id)
        {
            var response = await client.GetStringAsync("EmpSalaryDetails/" + id);

            return JsonConvert.DeserializeObject<EmpSalaryDetails>(response);
        }

        public async Task<IEnumerable<EmpSalaryDetails>> GetSalaryDetails()
        {
            var response = await client.GetStringAsync("EmpSalaryDetails");
            return JsonConvert.DeserializeObject<IEnumerable<EmpSalaryDetails>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SaveSalaryDetails(EmpSalaryDetails SalaryDtails)
        {
            var response = await client.PostAsJsonAsync("EmpSalaryDetails", SalaryDtails);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateSalaryDetails(EmpSalaryDetails SalaryDtails)
        {
            var response = await client.PutAsJsonAsync("EmpSalaryDetails/" + SalaryDtails.TransactionId, SalaryDtails);
            return response;
        }
    }
}
