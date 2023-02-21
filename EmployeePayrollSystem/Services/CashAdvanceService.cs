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
    public class CashAdvanceService : ICashAdvanceService
    {
        private HttpClient client;
        public CashAdvanceService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

        }
        public async Task<HttpResponseMessage> DeleteCashAdvance(int Id)
        {
            var response = await client.DeleteAsync("CashAdvance/" + Id);
            return response;
        }

        public async Task<CashAdvance> GetCashAdvance(int id)
        {
            var response = await client.GetStringAsync("CashAdvance/" + id);
            return JsonConvert.DeserializeObject<CashAdvance>(response);
        }

        public async Task<IEnumerable<CashAdvance>> GetCashAdvance()
        {
            var response = await client.GetStringAsync("CashAdvance");
            return JsonConvert.DeserializeObject<IEnumerable<CashAdvance>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SaveCashAdvance(CashAdvance cashAdvance)
        {
            var response = await client.PostAsJsonAsync("CashAdvance", cashAdvance);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateCashAdvance(CashAdvance cashAdvance)
        {
            var response = await client.PutAsJsonAsync("CashAdvance/" + cashAdvance.Id, cashAdvance);
            return response;
        }
    }
}
