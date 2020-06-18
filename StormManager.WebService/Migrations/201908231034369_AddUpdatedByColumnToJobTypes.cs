namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddUpdatedByColumnToJobTypes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTypes", "UpdatedBy", c => c.String());
            Sql("UPDATE JobTypes SET UpdatedBy = 'sqladmin'");
        }

        public override void Down()
        {
            DropColumn("dbo.JobTypes", "UpdatedBy");
        }
    }
}
