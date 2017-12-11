namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFaqAndGameFluentMap : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Id", "dbo.Faqs");
            DropPrimaryKey("dbo.Faqs");
            AlterColumn("dbo.Faqs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Faqs", "Id");
            CreateIndex("dbo.Faqs", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Faqs", new[] { "Id" });
            DropPrimaryKey("dbo.Faqs");
            AlterColumn("dbo.Faqs", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Faqs", "Id");
            AddForeignKey("dbo.Games", "Id", "dbo.Faqs", "Id");
        }
    }
}
