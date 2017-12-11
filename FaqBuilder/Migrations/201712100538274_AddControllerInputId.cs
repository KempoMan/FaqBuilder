namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddControllerInputId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ControllerInputs", "Motion", c => c.String());
            AddColumn("dbo.Platforms", "ControllerInputId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Platforms", "ControllerInputId");
            DropColumn("dbo.ControllerInputs", "Motion");
        }
    }
}
