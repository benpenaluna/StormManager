namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateGetAllJobTypesStoredProcedure : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("GetAllJobTypes");

            CreateStoredProcedure("GetAllJobTypes",
                p => new
                {
                    jsonOutput = p.String(outParameter: true)
                },
                @"SET @jsonOutput = (SELECT Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb 
                                          FROM dbo.JobTypes 
                                          ORDER BY Category, SubCategory
                                          FOR JSON AUTO)"
            );
        }
        
        public override void Down()
        {
            DropStoredProcedure("GetAllJobTypes");

            CreateStoredProcedure("GetAllJobTypes",
                p => new
                {
                    jsonOutput = p.String(outParameter: true)
                },
                @"SET @jsonOutput = (SELECT Id, Name, IsUsed, NewJobArgb, AgingJobArgb 
                                          FROM dbo.JobTypes 
                                          ORDER BY Name 
                                          FOR JSON AUTO)"
            );
        }
    }
}
