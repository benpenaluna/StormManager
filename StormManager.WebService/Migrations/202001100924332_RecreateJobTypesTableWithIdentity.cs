namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RecreateJobTypesTableWithIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                    "dbo.TempJobTypes",
                    c => new
                    {
                        Category = c.String(),
                        SubCategory = c.String(),
                        IsUsed = c.Boolean(nullable: false),
                        NewJobArgb = c.Int(nullable: false),
                        AgingJobArgb = c.Int(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UpdatedBy = c.String()
                    });

            Sql("INSERT INTO dbo.TempJobTypes (Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)" +
                "SELECT Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy " +
                "FROM dbo.JobTypes");

            DropTable("dbo.JobTypes");

            CreateTable(
                "dbo.JobTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Category = c.String(),
                    SubCategory = c.String(),
                    IsUsed = c.Boolean(nullable: false),
                    NewJobArgb = c.Int(nullable: false),
                    AgingJobArgb = c.Int(nullable: false),
                    DateUpdated = c.DateTime(nullable: false),
                    UpdatedBy = c.String()
                })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.JobTypes (Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)" +
                "SELECT Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy " +
                "FROM dbo.TempJobTypes");

            DropTable("dbo.TempJobTypes");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.TempJobTypes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: false),
                    Category = c.String(),
                    SubCategory = c.String(),
                    IsUsed = c.Boolean(nullable: false),
                    NewJobArgb = c.Int(nullable: false),
                    AgingJobArgb = c.Int(nullable: false),
                    DateUpdated = c.DateTime(nullable: false),
                    UpdatedBy = c.String()
                });

            Sql("INSERT INTO dbo.TempJobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)" +
                "SELECT Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy " +
                "FROM dbo.JobTypes");

            DropTable("dbo.JobTypes");

            CreateTable(
                    "dbo.JobTypes",
                    c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Category = c.String(),
                        SubCategory = c.String(),
                        IsUsed = c.Boolean(nullable: false),
                        NewJobArgb = c.Int(nullable: false),
                        AgingJobArgb = c.Int(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UpdatedBy = c.String()
                    })
                .PrimaryKey(t => t.Id);

            Sql("INSERT INTO dbo.JobTypes (Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy)" +
                "SELECT Id, Category, SubCategory, IsUsed, NewJobArgb, AgingJobArgb, DateUpdated, UpdatedBy " +
                "FROM dbo.TempJobTypes");

            DropTable("dbo.TempJobTypes");
        }
    }
}
