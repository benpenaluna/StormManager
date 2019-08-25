namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetAll_StoredProcedures : DbMigration
    {
        public override void Up()
        {
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
        
        public override void Down()
        {
            DropStoredProcedure("GetAll_StoredProcedures");
        }
    }
}
