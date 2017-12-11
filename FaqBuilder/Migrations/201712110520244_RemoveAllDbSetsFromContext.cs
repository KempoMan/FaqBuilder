namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAllDbSetsFromContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            DropForeignKey("dbo.Characters", "Id", "dbo.Games");
            DropForeignKey("dbo.ControllerInputs", "Id", "dbo.Platforms");
            DropIndex("dbo.Characters", new[] { "Id" });
            DropIndex("dbo.Games", new[] { "PlatformId" });
            DropIndex("dbo.ControllerInputs", new[] { "Id" });
            DropTable("dbo.Characters");
            DropTable("dbo.Games");
            DropTable("dbo.Platforms");
            DropTable("dbo.ControllerInputs");
            DropTable("dbo.Faqs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Faqs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ControllerInputs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Motion = c.String(),
                        Description = c.String(maxLength: 2000),
                        PlatformId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ShortName = c.String(maxLength: 10),
                        Description = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                        ShortName = c.String(maxLength: 10),
                        Description = c.String(maxLength: 2000),
                        PlatformId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 2000),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ControllerInputs", "Id");
            CreateIndex("dbo.Games", "PlatformId");
            CreateIndex("dbo.Characters", "Id");
            AddForeignKey("dbo.ControllerInputs", "Id", "dbo.Platforms", "Id");
            AddForeignKey("dbo.Characters", "Id", "dbo.Games", "Id");
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id");
        }
    }
}
