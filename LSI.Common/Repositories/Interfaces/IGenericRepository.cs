using LSI.Common.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Common.Repositories.Interfaces
{
    public interface IGenericRepository<TContext, TModel>
    where TContext : DbContext
    where TModel : BaseModel
    {
        IQueryable<TModel> GetAll();
        Task<List<TModel>> GetAllListAsync();
        IQueryable<TModel> FindBy(Expression<Func<TModel, bool>> predicate);
        Task<TModel> FindById(int id);
        Task<TModel> AddAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task<TModel> UpdateAsync(TModel model);
    }
}
