namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CorrectJobTypesIdProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JobTypes", "Id", c => c.Int(nullable: false, identity: true));
        }

        public override void Down()
        {
            AlterColumn("dbo.JobTypes", "Id", c => c.Int(nullable: false, identity: false));
        }
    }
}
