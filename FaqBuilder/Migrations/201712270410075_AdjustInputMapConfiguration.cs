namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustInputMapConfiguration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InputMaps", "GameId", "dbo.Games");
            DropForeignKey("dbo.InputMaps", "Id", "dbo.Games");
            DropIndex("dbo.InputMaps", new[] { "Id" });
            DropIndex("dbo.InputMaps", new[] { "GameId" });
            DropTable("dbo.InputMaps");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.InputMaps", "GameId");
            CreateIndex("dbo.InputMaps", "Id");
            AddForeignKey("dbo.InputMaps", "Id", "dbo.Games", "Id");
            AddForeignKey("dbo.InputMaps", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
