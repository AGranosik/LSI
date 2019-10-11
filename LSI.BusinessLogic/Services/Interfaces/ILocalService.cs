using LSI.Application.Repositories.Interfaces;
using LSI.BusinessLogic.Dtos;
using LSI.Common.Services.Interfaces;
using LSI.Data.Context;
using LSI.Data.Models;

namespace LSI.BusinessLogic.Services.Interfaces
{
    public interface ILocalService : IGenericService<LocalDto, ILocalRespository, Local, ExportDbContext>
    {

    }
}
