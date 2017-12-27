namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMovesAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moves", "MoveTypeId", "dbo.MoveTypes");
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Moves", new[] { "MoveTypeId" });
            DropIndex("dbo.Moves", new[] { "CharacterId" });
            DropTable("dbo.Moves");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        MoveTypeId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        Motion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Moves", "CharacterId");
            CreateIndex("dbo.Moves", "MoveTypeId");
            AddForeignKey("dbo.Moves", "CharacterId", "dbo.Characters", "Id");
            AddForeignKey("dbo.Moves", "MoveTypeId", "dbo.MoveTypes", "Id", cascadeDelete: true);
        }
    }
}
