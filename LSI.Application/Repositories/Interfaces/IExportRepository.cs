using LSI.Common.Repositories.Interfaces;
using LSI.Data.Context;
using LSI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Application.Repositories.Interfaces
{
    public interface IExportRepository : IGenericRepository<ExportDbContext, Export>
    {
    }
}
