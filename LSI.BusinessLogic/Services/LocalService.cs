using AutoMapper;
using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Dtos;
using LSI.BusinessLogic.Services.Interfaces;
using LSI.Common.Services;
using LSI.Data.Context;
using LSI.Data.Models;

namespace LSI.BusinessLogic.Services
{
    public class LocalService : GenericeService<LocalDto, ILocalRespository, Local, ExportDbContext>, ILocalService
    {
        public LocalService(ILocalRespository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
