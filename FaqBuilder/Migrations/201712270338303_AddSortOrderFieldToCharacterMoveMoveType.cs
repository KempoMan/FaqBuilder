namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSortOrderFieldToCharacterMoveMoveType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Characters", "SortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.MoveTypes", "SortOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Moves", "SortOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Moves", "SortOrder");
            DropColumn("dbo.MoveTypes", "SortOrder");
            DropColumn("dbo.Characters", "SortOrder");
        }
    }
}
