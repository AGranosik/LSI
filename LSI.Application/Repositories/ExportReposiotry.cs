using LSI.Application.Repositories.Interfaces;
using LSI.Common.Repositories;
using LSI.Data.Context;
using LSI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Application.Repositories
{
    public class ExportReposiotry : GenericRepository<ExportDbContext, Export>, IExportRepository
    {
        public ExportReposiotry(ExportDbContext context) : base(context)
        {
        }
    }
}
