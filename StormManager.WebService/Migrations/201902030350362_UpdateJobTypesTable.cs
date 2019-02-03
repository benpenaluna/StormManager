namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobTypesTable : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM JobTypes");

            AddColumn("dbo.JobTypes", "Category", c => c.String());
            AddColumn("dbo.JobTypes", "SubCategory", c => c.String());
            DropColumn("dbo.JobTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobTypes", "Name", c => c.String());
            DropColumn("dbo.JobTypes", "SubCategory");
            DropColumn("dbo.JobTypes", "Category");

            Sql("INSERT INTO JobTypes VALUES (1, 'Building Damage', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes VALUES (2, 'Flood', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes VALUES (3, 'Tree Down', 1, 0xFF90EE90, 0xFF008000)");
        }
    }
}
