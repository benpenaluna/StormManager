namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Name = c.String(),
                        IsUsed = c.Boolean(nullable: false),
                        NewJobArgb = c.Int(nullable: false),
                        AgingJobArgb = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            Sql("INSERT INTO JobTypes VALUES (1, 'Building Damage', 1, 0xFFFFB6C1, 0xFFFF0000)");
            Sql("INSERT INTO JobTypes VALUES (2, 'Flood', 1, 0xFFADD8E6, 0xFF0000FF)");
            Sql("INSERT INTO JobTypes VALUES (3, 'Tree Down', 1, 0xFF90EE90, 0xFF008000)");
        }
        
        public override void Down()
        {
            DropTable("dbo.JobTypes");
        }
    }
}
