using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.Domain.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        
    }
}
