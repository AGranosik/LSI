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
    public class GenericeService<UDto, TRepository, TModel, TContext> : IGenericService<UDto, TRepository, TModel, TContext>
        where UDto : BaseDto
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
        public async Task<UDto> AddAsync(UDto dto)
        {
            var model = await ConvertDtoToModel(dto);
            var insertedModel = await _repository.AddAsync(model);

            return await ConvertModelToDto(insertedModel);
        }

        public async Task DeleteAsync(UDto dto)
        {
            var model = await ConvertDtoToModel(dto);
            await _repository.DeleteAsync(model);
        }

        public async Task<UDto> FindById(int id)
        {
            var model = await _repository.FindById(id);
            if (model == null)
                throw new ModelNotFoundException(typeof(TModel).Name);

            return await ConvertModelToDto(model);
            
        }

        public async Task<List<UDto>> GetAllListAsync()
        {
            var modelList = await _repository.GetAllListAsync();

            return await ConvertModelListToDtoList(modelList);
        }

        public async Task<UDto> UpdateAsync(UDto dto)
        {
            var model = await ConvertDtoToModel(dto);
            var updatedModel = await _repository.UpdateAsync(model);

            return await ConvertModelToDto(updatedModel);
        }

        protected virtual async Task<List<TModel>> ConvertDtoListToModelList(List<UDto> list)
        {
            var modelList = new List<TModel>();
            foreach (var dto in list)
            {
                var model = await ConvertDtoToModel(dto);
                modelList.Add(model);
            }

            return modelList;
        }

        protected virtual async Task<UDto> ConvertModelToDto(TModel model)
        {
            return _mapper.Map<TModel, UDto>(model);
        }

        protected virtual async Task<TModel> ConvertDtoToModel(UDto dto)
        {
            return _mapper.Map<UDto, TModel>(dto);
        }

        protected virtual async Task<List<UDto>> ConvertModelListToDtoList(List<TModel> list)
        {
            var dtoList = new List<UDto>();
            foreach (var model in list)
            {
                var dto = await ConvertModelToDto(model);
                dtoList.Add(dto);
            }

            return dtoList;
        }
    }
}
