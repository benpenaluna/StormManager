namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetAllMembersStoredProcedure : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetAllMembers",
                p => new
                {
                    jsonOutput = p.String(outParameter: true)
                },
                @"SET @jsonOutput = (SELECT Id, FirstName, Surname, Position, Status, EmailAddress 
                                          FROM dbo.Members 
                                          ORDER BY Surname, FirstName 
                                          FOR JSON AUTO)"
            );
        }

        public override void Down()
        {
            DropStoredProcedure("GetAllMembers");
        }
    }
}
