namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMovesFromCharacterConfiguration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Moves", "Id", "dbo.Characters");
            DropIndex("dbo.Moves", new[] { "Id" });
            DropIndex("dbo.Moves", new[] { "CharacterId" });
            DropTable("dbo.Moves");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(maxLength: 100),
                        MoveTypeId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        Motion = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Moves", "CharacterId");
            CreateIndex("dbo.Moves", "Id");
            AddForeignKey("dbo.Moves", "Id", "dbo.Characters", "Id");
            AddForeignKey("dbo.Moves", "CharacterId", "dbo.Characters", "Id", cascadeDelete: true);
        }
    }
}
