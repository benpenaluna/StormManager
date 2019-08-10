namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobTypeStoredProcedure1 : DbMigration
    {
        public override void Up()
        {
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
        
        public override void Down()
        {
            DropStoredProcedure("Update_JobTypes");
        }
    }
}
