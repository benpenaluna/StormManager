namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateAddJobTypeStoredProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("Add_JobType", p => new
            {
                id = p.Int(),
                category = p.String(),
                subCategory = p.String(),
                isUsed = p.Boolean(),
                newJobArgb = p.Int(),
                agingJobArgb = p.Int(),
                dateUpdated = p.DateTime(),
                updatedBy = p.String()
            },
                @"INSERT INTO dbo.JobTypes
                        (Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)
                      VALUES
                        (@category, @subCategory, @isUsed, @newJobArgb, @agingJobArgb, @dateUpdated, @updatedBy)");
        }

        public override void Down()
        {
            DropStoredProcedure("Add_JobType");
        }
    }
}
