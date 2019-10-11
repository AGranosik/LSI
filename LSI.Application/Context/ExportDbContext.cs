using LSI.Data.Models;
using System.Data.Entity;

namespace LSI.Data.Context
{
    public class ExportDbContext : DbContext
    {
        public ExportDbContext() : base("ExportDB")
        {
        }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Local> Locals { get; set; }
    }
}
