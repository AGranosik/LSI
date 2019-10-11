using LSI.Common.Model;
using LSI.Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Common.Repositories
{
    public class GenericRepository<TContext, TModel> : IGenericRepository<TContext, TModel>
            where TContext : DbContext
            where TModel : BaseModel
    {

        protected readonly TContext _context;

        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TModel> AddAsync(TModel model)
        {
            _context.Set<TModel>().Add(model);
            await _context.SaveChangesAsync();

            return await FindById(model.ID);
        }

        public async Task DeleteAsync(TModel model)
        {
            _context.Set<TModel>().Remove(model);
            await _context.SaveChangesAsync();
        }

        public IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate)
        {
            return _context.Set<TModel>().Where(predicate);
        }

        public async Task<TModel> FindById(int id)
        {
            return await _context.Set<TModel>().SingleOrDefaultAsync(m => m.ID == id);
        }

        public IQueryable<TModel> GetAll()
        {
            return _context.Set<TModel>().AsQueryable();
        }

        public Task<List<TModel>> GetAllListAsync()
        {
            return _context.Set<TModel>().ToListAsync();
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var local = await FindById(model.ID);
            if (local != null)
            {
                _context.Entry(local).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();
                return await FindById(model.ID);
            }
            else
                return local; // null
            
        }
    }
}
