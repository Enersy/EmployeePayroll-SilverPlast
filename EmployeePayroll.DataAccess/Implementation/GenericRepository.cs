using EmployeePayroll.DataAccess.Context;
using EmployeePayroll.DataAccess.Exceptions;
using EmployeePayroll.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayroll.DataAccess.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EmployeePayrollDbContext _context;
        public DbSet<T> dbSet;
        public GenericRepository(EmployeePayrollDbContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public virtual async Task Add(T entity)
        {
           
                    _context.Set<T>().Add(entity);
                    _context.SaveChanges();

            
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return  _context.Set<T>().Where(predicate).AsNoTracking();
        }

        public virtual  IQueryable<T> GetAll()
        {
            return  _context.Set<T>().AsNoTracking();
        }


        public async virtual Task Update(T entity)
        {

            _context.Set<T>().Update(entity);

        }

      
    }
}
