namespace FaqBuilder.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustColumnNamesForMoveTypesLookup : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.GamesMoveTypes", name: "MoveTypeId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GamesMoveTypes", name: "GameId", newName: "MoveTypeId");
            RenameColumn(table: "dbo.GamesMoveTypes", name: "__mig_tmp__0", newName: "GameId");
            RenameIndex(table: "dbo.GamesMoveTypes", name: "IX_MoveTypeId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GamesMoveTypes", name: "IX_GameId", newName: "IX_MoveTypeId");
            RenameIndex(table: "dbo.GamesMoveTypes", name: "__mig_tmp__0", newName: "IX_GameId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GamesMoveTypes", name: "IX_GameId", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.GamesMoveTypes", name: "IX_MoveTypeId", newName: "IX_GameId");
            RenameIndex(table: "dbo.GamesMoveTypes", name: "__mig_tmp__0", newName: "IX_MoveTypeId");
            RenameColumn(table: "dbo.GamesMoveTypes", name: "GameId", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.GamesMoveTypes", name: "MoveTypeId", newName: "GameId");
            RenameColumn(table: "dbo.GamesMoveTypes", name: "__mig_tmp__0", newName: "MoveTypeId");
        }
    }
}
