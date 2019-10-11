namespace LSI.Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTimetomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exports", "Time", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exports", "Time");
        }
    }
}
