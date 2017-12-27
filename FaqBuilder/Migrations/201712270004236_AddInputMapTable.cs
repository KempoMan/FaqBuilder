namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInputMapTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InputMaps",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Input = c.String(nullable: false, maxLength: 255),
                        ConvertedInput = c.String(nullable: false, maxLength: 255),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InputMaps", "Id", "dbo.Games");
            DropForeignKey("dbo.InputMaps", "GameId", "dbo.Games");
            DropIndex("dbo.InputMaps", new[] { "GameId" });
            DropIndex("dbo.InputMaps", new[] { "Id" });
            DropTable("dbo.InputMaps");
        }
    }
}
