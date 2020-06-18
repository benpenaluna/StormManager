namespace StormManager.WebService.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddKeyInParametersColumnToRoutinesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routines", "KeyInParameters", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Routines", "KeyInParameters");
        }
    }
}
