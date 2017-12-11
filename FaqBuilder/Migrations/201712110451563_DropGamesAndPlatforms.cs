namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropGamesAndPlatforms : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            AlterColumn("dbo.Games", "Name", c => c.String());
            AlterColumn("dbo.Games", "ShortName", c => c.String());
            AlterColumn("dbo.Games", "Description", c => c.String());
            AlterColumn("dbo.Platforms", "Name", c => c.String());
            AlterColumn("dbo.Platforms", "ShortName", c => c.String());
            AlterColumn("dbo.Platforms", "Description", c => c.String());
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "PlatformId", "dbo.Platforms");
            AlterColumn("dbo.Platforms", "Description", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Platforms", "ShortName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Platforms", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Games", "Description", c => c.String(maxLength: 2000));
            AlterColumn("dbo.Games", "ShortName", c => c.String(maxLength: 10));
            AlterColumn("dbo.Games", "Name", c => c.String(maxLength: 255));
            AddForeignKey("dbo.Games", "PlatformId", "dbo.Platforms", "Id");
        }
    }
}
