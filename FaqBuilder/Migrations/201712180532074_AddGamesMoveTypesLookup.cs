namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamesMoveTypesLookup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MoveTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GamesMoveTypes",
                c => new
                    {
                        MoveTypeId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MoveTypeId, t.GameId })
                .ForeignKey("dbo.Games", t => t.MoveTypeId, cascadeDelete: true)
                .ForeignKey("dbo.MoveTypes", t => t.GameId, cascadeDelete: true)
                .Index(t => t.MoveTypeId)
                .Index(t => t.GameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GamesMoveTypes", "GameId", "dbo.MoveTypes");
            DropForeignKey("dbo.GamesMoveTypes", "MoveTypeId", "dbo.Games");
            DropIndex("dbo.GamesMoveTypes", new[] { "GameId" });
            DropIndex("dbo.GamesMoveTypes", new[] { "MoveTypeId" });
            DropTable("dbo.GamesMoveTypes");
            DropTable("dbo.MoveTypes");
        }
    }
}
