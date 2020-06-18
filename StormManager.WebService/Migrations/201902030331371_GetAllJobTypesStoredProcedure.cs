namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class GetAllJobTypesStoredProcedure : DbMigration
    {
        public override void Up()
        {
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

        public override void Down()
        {
            DropStoredProcedure("GetAllJobTypes");
        }
    }
}
