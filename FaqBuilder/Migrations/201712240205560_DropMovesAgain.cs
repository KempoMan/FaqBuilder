namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropMovesAgain : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            AlterColumn("dbo.Moves", "Name", c => c.String());
            AlterColumn("dbo.Moves", "Motion", c => c.String());
            AddForeignKey("dbo.Moves", "CharacterId", "dbo.Characters", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Moves", "CharacterId", "dbo.Characters");
            AlterColumn("dbo.Moves", "Motion", c => c.String(maxLength: 250));
            AlterColumn("dbo.Moves", "Name", c => c.String(maxLength: 100));
            AddForeignKey("dbo.Moves", "CharacterId", "dbo.Characters", "Id");
        }
    }
}
