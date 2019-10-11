using AutoMapper;
using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Dtos;
using LSI.BusinessLogic.Filters;
using LSI.BusinessLogic.Services.Interfaces;
using LSI.Common.Exceptions;
using LSI.Common.Services;
using LSI.Data.Context;
using LSI.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace LSI.BusinessLogic.Services
{
    public class ExportService : GenericeService<ExportDto, IExportRepository, Export, ExportDbContext>, IExportService
    {
        private readonly ILocalRespository _localRepository;
        public ExportService(IExportRepository repository, ILocalRespository localRespository, IMapper mapper) : base(repository, mapper)
        {
            _localRepository = localRespository;
        }

        public async Task<Tuple<List<ExportDto>, int>> FilteredListAsync(ExportFilter filter)
        {
            FilterValidation(filter);
            var query = _repository.GetAll();
            var numberOfModels = query.Count();

            if (filter.From.HasValue)
                query = query.Where(e => e.Date.CompareTo(filter.From.Value) >= 0);

            if(filter.To.HasValue)
                query = query.Where(e => e.Date.CompareTo(filter.To.Value) <= 0);

            if (filter.LocalId.HasValue)
                query = query.Where(e => e.LocalId == filter.LocalId.Value);

            query = query.OrderBy(e => e.Date);


            query = PaginateQuery(query, filter);

            var exportModelList = await query.ToListAsync();

            var dtoList = await ConvertModelListToDtoList(exportModelList);

            return new Tuple<List<ExportDto>, int>(dtoList, numberOfModels);
        }

        private void FilterValidation(ExportFilter filter)
        {
            if(filter.From.HasValue && filter.To.HasValue)
            {
                if (DateTime.Compare(filter.From.Value, filter.To.Value) > 0)
                    throw new WrongParemetrsException("Date 'from' cannot be later than Date 'to'");
            }
        }
    }
}
