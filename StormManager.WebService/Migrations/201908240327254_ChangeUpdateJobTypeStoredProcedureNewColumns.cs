namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangeUpdateJobTypeStoredProcedureNewColumns : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("Update_JobTypes");

            CreateStoredProcedure("Update_JobTypes", p => new
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
                @"UPDATE dbo.JobTypes
                      SET Category = @category, 
                          SubCategory = @subCategory, 
                          IsUsed = @isUsed, 
                          NewJobArgb = @newJobArgb, 
                          AgingJobArgb = @agingJobArgb,
                          DateUpdated = @dateUpdated,
                          UpdatedBy = @updatedBy
                       WHERE Id = @id");
        }

        public override void Down()
        {
            DropStoredProcedure("Update_JobTypes");

            CreateStoredProcedure("Update_JobTypes", p => new
            {
                id = p.Int(),
                category = p.String(),
                subCategory = p.String(),
                isUsed = p.Boolean(),
                newJobArgb = p.Int(),
                agingJobArgb = p.Int()
            },
                @"UPDATE dbo.JobTypes
                       SET Category = @category, SubCategory = @subCategory, IsUsed = @isUsed, NewJobArgb = @newJobArgb, AgingJobArgb = @agingJobArgb
                       WHERE Id = @id");
        }
    }
}
