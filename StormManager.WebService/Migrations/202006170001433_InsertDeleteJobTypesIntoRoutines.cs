namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InsertDeleteJobTypesIntoRoutines : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Routines (TableName, TransactionType, StoredProcedureName, KeyInParameters) " +
                "VALUES ('JobType', 'Deletion', 'Delete_JobType', 1)");
        }

        public override void Down()
        {
            Sql("DELETE FROM dbo.Routines" +
                "WHERE TableName = 'JobType' AND TransactionType = 'Deletion'");
        }
    }
}