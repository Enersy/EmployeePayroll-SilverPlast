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

        public async void SaveCat(Category Category)
        {
            await client.PostAsJsonAsync("Category", Category);
        }

        public async void DeleteCat(int Id)
        {
            await client.DeleteAsync("Category/" + Id);

        }

        public async void UpdateCat(Category Category)
        {
            await client.PutAsJsonAsync("Category/" + Category.Id, Category);

        }

        public async Task<IEnumerable<Category>> GetCats()
        {
            var response = await client.GetStringAsync("Category");
            return JsonConvert.DeserializeObject<IEnumerable<Category>>(response).ToList();

        }

        
    }
}
