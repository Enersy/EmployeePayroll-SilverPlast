using EmployeePayroll.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollSystem.Services
{
    public interface ICategoryService
    {
        //Task<Category> GetCat();
        Task<Category> GetCategory(int id);
        void DeleteCat(int Id);
        void UpdateCat(Category Category);
        Task<IEnumerable<Category>> GetCats();
        void SaveCat(Category Category);

    }
}
