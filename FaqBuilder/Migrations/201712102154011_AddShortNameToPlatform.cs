namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortNameToPlatform : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Platforms", "ShortName", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Platforms", "ShortName");
        }
    }
}
