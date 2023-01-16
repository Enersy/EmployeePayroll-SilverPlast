using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface ICategoryService
    {
        //Task<Category> GetCat();
        Task<Category> GetCategory(int id);
        Task<IEnumerable<Category>> GetCats();
        Task<HttpResponseMessage> DeleteCat(int Id);
        Task<HttpResponseMessage> UpdateCat(Category Category);
        Task<HttpResponseMessage> SaveCat(Category Category);

    }
}
