namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveTypeConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MoveTypes", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.MoveTypes", "Description", c => c.String(maxLength: 2000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MoveTypes", "Description", c => c.String());
            AlterColumn("dbo.MoveTypes", "Name", c => c.String());
        }
    }
}
