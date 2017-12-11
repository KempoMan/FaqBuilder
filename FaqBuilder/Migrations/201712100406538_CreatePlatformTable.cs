namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePlatformTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ControllerInputs");
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ControllerInputs", "PlatformId", c => c.Int(nullable: false));
            AlterColumn("dbo.ControllerInputs", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ControllerInputs", "Id");
            CreateIndex("dbo.ControllerInputs", "Id");
            AddForeignKey("dbo.ControllerInputs", "Id", "dbo.Platforms", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ControllerInputs", "Id", "dbo.Platforms");
            DropIndex("dbo.ControllerInputs", new[] { "Id" });
            DropPrimaryKey("dbo.ControllerInputs");
            AlterColumn("dbo.ControllerInputs", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.ControllerInputs", "PlatformId");
            DropTable("dbo.Platforms");
            AddPrimaryKey("dbo.ControllerInputs", "Id");
        }
    }
}
