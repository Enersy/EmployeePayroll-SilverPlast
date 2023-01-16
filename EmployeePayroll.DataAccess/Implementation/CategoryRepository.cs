using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.Domain.Entities;
using EmployeePayroll.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess.Implementation
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly EmployeePayrollDbContext _context;
        public CategoryRepository(EmployeePayrollDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteCategory(int Id)
        {
            var Cat =  _context.Categories.Where(x => x.Id == Id).FirstOrDefault();
            _context.Categories.Remove(Cat);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return  _context.Categories;
        }


        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
