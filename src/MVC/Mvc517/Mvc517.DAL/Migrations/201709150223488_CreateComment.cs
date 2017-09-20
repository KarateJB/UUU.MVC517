namespace Mvc517.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateComment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Operas", "CommentId", c => c.Int());
            CreateIndex("dbo.Operas", "CommentId");
            AddForeignKey("dbo.Operas", "CommentId", "dbo.Comments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operas", "CommentId", "dbo.Comments");
            DropIndex("dbo.Operas", new[] { "CommentId" });
            DropColumn("dbo.Operas", "CommentId");
            DropTable("dbo.Comments");
        }
    }
}
