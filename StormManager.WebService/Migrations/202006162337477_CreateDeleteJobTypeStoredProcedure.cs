using System.Data.Entity.Migrations;

namespace StormManager.WebService.Migrations
{
    public partial class CreateDeleteJobTypeStoredProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Delete_JobType", p => new
            {
                id = p.Int()
            },
            @"DELETE FROM dbo.JobTypes 
              WHERE Id = @id;");
        }

        public override void Down()
        {
            DropStoredProcedure("Delete_JobType");
        }
    }
}
