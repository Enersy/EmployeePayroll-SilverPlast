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
    public class CategoryService:ICategoryService
    {
        private HttpClient client;
        public CategoryService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7133/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json")
                );
        }

        public async Task<HttpResponseMessage> SaveCat(Category Category)
        {
           var response = await client.PostAsJsonAsync("Category", Category);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteCat(int Id)
        {
           var response = await client.DeleteAsync("Category/" + Id);
            return response;

        }

        public async Task<HttpResponseMessage> UpdateCat(Category Category)
        {
           var response = await client.PutAsJsonAsync("Category/" + Category.Id, Category);
            return response;

        }

        public async Task<IEnumerable<Category>> GetCats()
        {
            var response = await client.GetStringAsync("Category");
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(response).ToList();

        }

        public async Task<Category> GetCategory(int id)
        {
            var response = await client.GetStringAsync("Catwgory/"+ id);

            return JsonConvert.DeserializeObject<Category>(response);
        }
    }
}
