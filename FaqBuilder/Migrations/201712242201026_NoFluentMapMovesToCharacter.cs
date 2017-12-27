namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoFluentMapMovesToCharacter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MoveTypeId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                        Motion = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MoveTypes", t => t.MoveTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.CharacterId)
                .Index(t => t.MoveTypeId)
                .Index(t => t.CharacterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            DropForeignKey("dbo.Moves", "MoveTypeId", "dbo.MoveTypes");
            DropIndex("dbo.Moves", new[] { "CharacterId" });
            DropIndex("dbo.Moves", new[] { "MoveTypeId" });
            DropTable("dbo.Moves");
        }
    }
}
