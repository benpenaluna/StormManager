namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeGetAll_StoredProcedures_Procedure : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("GetAll_StoredProcedures");

            CreateStoredProcedure("GetAll_StoredProcedures",
                p => new
                {
                    jsonOutput = p.String(outParameter: true)
                },
                @"SET @jsonOutput = (SELECT * 
                                         FROM [dbo].[Routines] 
                                         FOR JSON AUTO)"
            );
        }

        public override void Down()
        {
            DropStoredProcedure("GetAll_StoredProcedures");

            CreateStoredProcedure("GetAll_StoredProcedures",
                p => new
                {
                    jsonOutput = p.String(outParameter: true)
                },
                @"SET @jsonOutput = (SELECT * 
                                         FROM [INFORMATION_SCHEMA].[ROUTINES] 
                                         FOR JSON AUTO)"
            );
        }
    }
}
