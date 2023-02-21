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
    public class WagerSalaryDetailsService : IWageSalaryDetailsService
    {
        private HttpClient client;
        public WagerSalaryDetailsService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }
        public async Task<HttpResponseMessage> DeletePieceRateSalaryDetails(int Id)
        {
            var response = await client.DeleteAsync("WagerSalaryDetails/" + Id);
            return response;
        }

        public async Task<EmpWagerSalaryDetails> GetPieceRateSalaryDetails(int id)
        {
            var response = await client.GetStringAsync("WagerSalaryDetails/" + id);

            return JsonConvert.DeserializeObject<EmpWagerSalaryDetails>(response);
        }

        public async Task<IEnumerable<EmpWagerSalaryDetails>> GetPieceRateSalaryDetails()
        {
            var response = await client.GetStringAsync("WagerSalaryDetails");
            return JsonConvert.DeserializeObject<IEnumerable<EmpWagerSalaryDetails>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SavePieceRateSalaryDetails(EmpWagerSalaryDetails SalaryDetails)
        {
            var response = await client.PostAsJsonAsync("WagerSalaryDetails", SalaryDetails);
            return response;
        }

        public async Task<HttpResponseMessage> UpdatePieceRateSalaryDetails(EmpWagerSalaryDetails SalaryDetails)
        {
            var response = await client.PutAsJsonAsync("WagerSalaryDetails/" + SalaryDetails.TransactionId, SalaryDetails);
            return response;
        }
    }
}
