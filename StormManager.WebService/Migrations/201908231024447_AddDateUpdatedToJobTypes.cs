namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDateUpdatedToJobTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTypes", "DateUpdated", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.JobTypes", "DateUpdated");
        }
    }
}
