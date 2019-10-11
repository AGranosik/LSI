using AutoMapper;
using LSI.Common.Exceptions;
using LSI.Common.Model;
using LSI.Common.Repositories.Interfaces;
using LSI.Common.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Common.Services
{
    public class GenericeService<UVM, TRepository, TModel, TContext> : IGenericService<UVM, TRepository, TModel, TContext>
        where UVM : BaseDto
        where TModel : BaseModel
        where TContext : DbContext
        where TRepository : IGenericRepository<TContext, TModel>
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;


        public GenericeService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IQueryable<TModel> PaginateQuery(IQueryable<TModel> query, Pagination pagination)
        {
            return query.Skip((pagination.Page - 1) * pagination.PageSize)
                .Take(pagination.PageSize);
        }

        public async Task<UVM> AddAsync(UVM dto)
        {
            var model = await ConvertDtoToModel(dto);
            var insertedModel = await _repository.AddAsync(model);

            return await ConvertModelToVM(insertedModel);
        }

        public async Task DeleteAsync(UVM dto)
        {
            var model = await ConvertDtoToModel(dto);
            await _repository.DeleteAsync(model);
        }

        public async Task<UVM> FindById(int id)
        {
            var model = await _repository.FindById(id);
            if (model == null)
                throw new ModelNotFoundException(typeof(TModel).Name);

            return await ConvertModelToVM(model);
            
        }

        public async Task<List<UVM>> GetAllListAsync()
        {
            var modelList = await _repository.GetAllListAsync();

            return await ConvertModelListToDtoList(modelList);
        }

        public async Task<UVM> UpdateAsync(UVM dto)
        {
            var model = await ConvertDtoToModel(dto);
            var updatedModel = await _repository.UpdateAsync(model);

            return await ConvertModelToVM(updatedModel);
        }

        protected virtual async Task<List<TModel>> ConvertDtoListToModelList(List<UVM> list)
        {
            var modelList = new List<TModel>();
            foreach (var dto in list)
            {
                var model = await ConvertDtoToModel(dto);
                modelList.Add(model);
            }

            return modelList;
        }

        protected virtual async Task<UVM> ConvertModelToVM(TModel model)
        {
            return _mapper.Map<TModel, UVM>(model);
        }

        protected virtual async Task<TModel> ConvertDtoToModel(UVM dto)
        {
            return _mapper.Map<UVM, TModel>(dto);
        }

        protected virtual async Task<List<UVM>> ConvertModelListToDtoList(List<TModel> list)
        {
            var dtoList = new List<UVM>();
            foreach (var model in list)
            {
                var dto = await ConvertModelToVM(model);
                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
