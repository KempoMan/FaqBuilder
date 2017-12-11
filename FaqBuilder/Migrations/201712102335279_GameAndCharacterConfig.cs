namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameAndCharacterConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        Description = c.String(maxLength: 2000),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 255),
                        ShortName = c.String(maxLength: 10),
                        Description = c.String(maxLength: 2000),
                        PlatformId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Platforms", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "Id", "dbo.Games");
            DropForeignKey("dbo.Games", "Id", "dbo.Platforms");
            DropIndex("dbo.Games", new[] { "Id" });
            DropIndex("dbo.Characters", new[] { "Id" });
            DropTable("dbo.Games");
            DropTable("dbo.Characters");
        }
    }
}
