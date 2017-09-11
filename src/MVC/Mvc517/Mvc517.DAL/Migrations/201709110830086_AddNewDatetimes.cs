namespace Mvc517.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewDatetimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operas", "CreateOn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Operas", "UpdateOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Operas", "UpdateOn");
            DropColumn("dbo.Operas", "CreateOn");
        }
    }
}
