namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNavigationPropertiesFromFaq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faqs", "Id", "dbo.Games");
            DropForeignKey("dbo.Games", "FaqId", "dbo.Faqs");
            DropIndex("dbo.Games", new[] { "FaqId" });
            DropIndex("dbo.Faqs", new[] { "Id" });
            DropPrimaryKey("dbo.Faqs");
            AlterColumn("dbo.Faqs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Faqs", "Id");
            DropColumn("dbo.Games", "FaqId");
            DropColumn("dbo.Faqs", "GameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Faqs", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "FaqId", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Faqs");
            AlterColumn("dbo.Faqs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Faqs", "Id");
            CreateIndex("dbo.Faqs", "Id");
            CreateIndex("dbo.Games", "FaqId");
            AddForeignKey("dbo.Games", "FaqId", "dbo.Faqs", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Faqs", "Id", "dbo.Games", "Id");
        }
    }
}
