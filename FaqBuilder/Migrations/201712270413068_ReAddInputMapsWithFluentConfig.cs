namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReAddInputMapsWithFluentConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InputMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Input = c.String(),
                        ConvertedInput = c.String(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InputMaps", "GameId", "dbo.Games");
            DropIndex("dbo.InputMaps", new[] { "GameId" });
            DropTable("dbo.InputMaps");
        }
    }
}
