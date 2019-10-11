using LSI.Common.Model;
using LSI.Common.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Common.Services.Interfaces
{
    public interface IGenericService<UDto, TRepository, TModel, TContext>
        where UDto : BaseDto
        where TModel : BaseModel
        where TContext : DbContext
        where TRepository: IGenericRepository<TContext, TModel>
    {
        Task<List<UDto>> GetAllListAsync();
        Task<UDto> FindById(int id);
        Task<UDto> AddAsync(UDto model);
        Task DeleteAsync(UDto model);
        Task<UDto> UpdateAsync(UDto model);
        IQueryable<TModel> PaginateQuery(IQueryable<TModel> query,  Pagination pagination);
    }
}
