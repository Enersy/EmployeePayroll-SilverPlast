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
        public virtual async Task<bool> Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.dbSet.Add(entity);
                this._context.SaveChanges();
                 return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                //foreach (var validationErrors in dbEx.EntityValidationErrors)
                //{
                //    foreach (var validationError in validationErrors)
                //    {
                //        msg += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //    }
                //}.

                var fail = new Exception(msg, dbEx);
                throw fail;
            }
            //  await dbSet.AddAsync(entity);
            
        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync();
        }

        public virtual void Update(T entity)
        {
           
           
                 throw new NotImplementedException();

        }
    }
}
