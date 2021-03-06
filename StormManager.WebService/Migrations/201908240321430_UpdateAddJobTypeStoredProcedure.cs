namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class UpdateAddJobTypeStoredProcedure : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("Add_JobType");

            CreateStoredProcedure("Add_JobType", p => new
            {
                id = p.Int(),
                category = p.String(),
                subCategory = p.String(),
                isUsed = p.Boolean(),
                newJobArgb = p.Int(),
                agingJobArgb = p.Int(),
                dateUpdated = p.DateTime(),
                updatedBy = p.String(maxLength: 8)
            },
                @"INSERT INTO dbo.JobTypes
                        (Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)
                      VALUES
                        (@category, @subCategory, @isUsed, @newJobArgb, @agingJobArgb, @dateUpdated, @updatedBy)");
        }

        public override void Down()
        {
            DropStoredProcedure("Add_JobType");

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
    }
}
