namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoveTable : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Characters", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moves", "Id", "dbo.Characters");
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            DropIndex("dbo.Moves", new[] { "CharacterId" });
            DropIndex("dbo.Moves", new[] { "Id" });
            DropTable("dbo.Moves");
        }
    }
}
