namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFaqToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Games", "FaqId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Games", "Id", "dbo.Faqs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Id", "dbo.Faqs");
            DropColumn("dbo.Games", "FaqId");
            DropTable("dbo.Faqs");
        }
    }
}
