using AutoMapper;
using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Dtos;
using LSI.BusinessLogic.Services.Interfaces;
using LSI.Common.Services;
using LSI.Data.Context;
using LSI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.BusinessLogic.Services
{
    public class ExportService : GenericeService<ExportDto, IExportRepository, Export, ExportDbContext>, IExportService
    {
        public ExportService(IExportRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
