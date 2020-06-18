namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddStoredProceduresTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routines",
                c => new
                {
                    TableName = c.String(nullable: false, maxLength: 128),
                    TransactionType = c.String(nullable: false, maxLength: 128),
                    StoredProcedureName = c.String(),
                })
                .PrimaryKey(t => new { t.TableName, t.TransactionType });

        }

        public override void Down()
        {
            DropTable("dbo.Routines");
        }
    }
}
