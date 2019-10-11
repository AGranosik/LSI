using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Dtos;
using LSI.BusinessLogic.Filters;
using LSI.Common.Services.Interfaces;
using LSI.Data.Context;
using LSI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.BusinessLogic.Services.Interfaces
{
    public interface IExportService : IGenericService<ExportDto, IExportRepository, Export, ExportDbContext>
    {
        Task<List<ExportDto>> FilteredList(ExportFilter filter);
    }
}
