namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ControllerInputs", "Description", c => c.String(maxLength: 2000));
            AddColumn("dbo.Platforms", "Description", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Platforms", "Description");
            DropColumn("dbo.ControllerInputs", "Description");
        }
    }
}
