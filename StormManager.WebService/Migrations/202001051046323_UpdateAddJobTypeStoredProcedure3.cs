namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddJobTypeStoredProcedure3 : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("Add_JobType");

            CreateStoredProcedure("Add_JobType", p => new
                {
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
                        (@category, @subCategory, @isUsed, @newJobArgb, @agingJobArgb, @dateUpdated, @updatedBy)
                      SELECT SCOPE_IDENTITY() AS Id");
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
                    updatedBy = p.String(maxLength: 8)
                },
                @"INSERT INTO dbo.JobTypes
                        (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)
                      VALUES
                        (@Id, @category, @subCategory, @isUsed, @newJobArgb, @agingJobArgb, @dateUpdated, @updatedBy)");
        }
    }
}
