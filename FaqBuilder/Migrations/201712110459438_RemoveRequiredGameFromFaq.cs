namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredGameFromFaq : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Faqs", "Id", "dbo.Games");
            CreateIndex("dbo.Games", "FaqId");
            AddForeignKey("dbo.Games", "FaqId", "dbo.Faqs", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "FaqId", "dbo.Faqs");
            DropIndex("dbo.Games", new[] { "FaqId" });
            AddForeignKey("dbo.Faqs", "Id", "dbo.Games", "Id");
        }
    }
}
