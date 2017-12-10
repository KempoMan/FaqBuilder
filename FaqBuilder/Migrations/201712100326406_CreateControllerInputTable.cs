namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateControllerInputTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ControllerInputs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ControllerInputs");
        }
    }
}
