namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedUpdatedByMaxLengthInJobTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobTypes", "UpdatedBy", c => c.String(maxLength: 8));
        }

        public override void Down()
        {
            AlterColumn("dbo.JobTypes", "UpdatedBy", c => c.String());
        }
    }
}
