namespace LSI.Application.Migrations
{
    using LSI.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LSI.Data.Context.ExportDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LSI.Data.Context.ExportDbContext context)
        {
            var exports = new List<Export>();
            var users = new List<User>();
            var locals = new List<Local>();

            users.Add(new User { ID = 1, Name = "user1" });
            users.Add(new User { ID = 2, Name = "user2" });

            locals.Add(new Local { ID = 1, Name = "local1" });
            locals.Add(new Local { ID = 2, Name = "local2" });


            exports.Add(new Export { Date = DateTime.Now, Name = "export1", LocalId = 1, UserId = 1 });
            exports.Add(new Export { Date = new DateTime(2019, 10, 12), Name = "export2", LocalId = 2, UserId = 1 });
            exports.Add(new Export { Date = new DateTime(2019, 10, 14), Name = "export3", LocalId = 1, UserId = 2 });
            exports.Add(new Export { Date = new DateTime(2019, 10, 15), Name = "export4", LocalId = 2, UserId = 1 });
            exports.Add(new Export { Date = new DateTime(2019, 10, 15), Name = "export5", LocalId = 1, UserId = 1 });
            exports.Add(new Export { Date = new DateTime(2019, 10, 15), Name = "export6", LocalId = 2, UserId = 2 });
            exports.Add(new Export { Date = new DateTime(2019, 10, 17), Name = "export7", LocalId = 1, UserId = 1 });
            exports.Add(new Export { Date = new DateTime(2018, 10, 12), Name = "export8", LocalId = 2, UserId = 1 });

            context.Users.AddRange(users);
            context.Locals.AddRange(locals);
            context.Exports.AddRange(exports);
        }
    }
}
