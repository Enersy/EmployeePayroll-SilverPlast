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
    public class LoanService : ILoanService
    {
        private HttpClient client;
        public LoanService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );

        }
        public async Task<HttpResponseMessage> DeleteLoan(int Id)
        {
            var response = await client.DeleteAsync("Loan/" + Id);
            return response;
        }

        public async Task<Loan> GetLoan(int id)
        {
            var response = await client.GetStringAsync("Loan/" + id);
            return JsonConvert.DeserializeObject<Loan>(response);
        }

        public async Task<IEnumerable<Loan>> GetLoans()
        {
            var response = await client.GetStringAsync("Loan");
            return JsonConvert.DeserializeObject<IEnumerable<Loan>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SaveLoan(Loan loan)
        {
            var response = await client.PostAsJsonAsync("Loan", loan);
            return response;
        }

        public async Task<HttpResponseMessage> UpdateLoan(Loan loan)
        {
            var response = await client.PutAsJsonAsync("Loan/" + loan.Id, loan);
            return response;
        }
    }
}
