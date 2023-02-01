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
    public class PieceRateSalaryDetailsService : IEmpPieceRateSalaryDetailsService
    {
        private HttpClient client;
        public PieceRateSalaryDetailsService()
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
            var response = await client.DeleteAsync("PieceRateSalaryDetails/" + Id);
            return response;
        }

        public async Task<EmpPieceRateSalaryDetails> GetPieceRateSalaryDetails(int id)
        {
            var response = await client.GetStringAsync("PieceRateSalaryDetails/" + id);

            return JsonConvert.DeserializeObject<EmpPieceRateSalaryDetails>(response);
        }

        public async Task<IEnumerable<EmpPieceRateSalaryDetails>> GetPieceRateSalaryDetails()
        {
            var response = await client.GetStringAsync("EmpPieceRateSalaryDetails");
            return JsonConvert.DeserializeObject<IEnumerable<EmpPieceRateSalaryDetails>>(response).ToList();
        }

        public async Task<HttpResponseMessage> SavePieceRateSalaryDetails(EmpPieceRateSalaryDetails PieceRateSalaryDetails)
        {
            var response = await client.PostAsJsonAsync("EmpPieceRateSalaryDetails", PieceRateSalaryDetails);
            return response;
        }

        public async Task<HttpResponseMessage> UpdatePieceRateSalaryDetails(EmpPieceRateSalaryDetails PieceRateSalaryDetails)
        {
            var response = await client.PutAsJsonAsync("EmpPieceRateSalaryDetails/" + PieceRateSalaryDetails.TransactionId, PieceRateSalaryDetails);
            return response;
        }
    }
}
