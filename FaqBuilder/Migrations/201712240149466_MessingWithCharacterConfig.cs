namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MessingWithCharacterConfig : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moves", "Id", "dbo.Characters");
            DropIndex("dbo.Moves", new[] { "Id" });
            DropPrimaryKey("dbo.Moves");
            AlterColumn("dbo.Moves", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Moves", "Name", c => c.String());
            AlterColumn("dbo.Moves", "Motion", c => c.String());
            AddPrimaryKey("dbo.Moves", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Moves");
            AlterColumn("dbo.Moves", "Motion", c => c.String(maxLength: 250));
            AlterColumn("dbo.Moves", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Moves", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Moves", "Id");
            CreateIndex("dbo.Moves", "Id");
            AddForeignKey("dbo.Moves", "Id", "dbo.Characters", "Id");
        }
    }
}
