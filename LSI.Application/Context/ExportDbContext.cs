using LSI.Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSI.Application.Context
{
    public class ExportDbContext : DbContext
    {
        public ExportDbContext() : base("ExportDB")
        {
            Database.SetInitializer(new ExportDBInitializer());
        }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Local> Locals { get; set; }
    }
}
