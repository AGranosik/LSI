using LSI.Application.Repositories.Interfaces;
using System;
using LSI.Data.Models;
using System.Threading.Tasks;
using LSI.Data.Context;

namespace LSI.Application.Repositories
{
    public class Logger : ILogger
    {
        private readonly ExportDbContext _context;
        public Logger(ExportDbContext context)
        {
            _context = context;
        }
        public async Task LogException(Exception ex)
        {
            var Log = new Log(ex);
            _context.Logs.Add(Log);
            await _context.SaveChangesAsync();
        }
    }
}
