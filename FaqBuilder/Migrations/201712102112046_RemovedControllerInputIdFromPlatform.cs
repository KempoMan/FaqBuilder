namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedControllerInputIdFromPlatform : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Platforms", "ControllerInputId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Platforms", "ControllerInputId", c => c.Int(nullable: false));
        }
    }
}
