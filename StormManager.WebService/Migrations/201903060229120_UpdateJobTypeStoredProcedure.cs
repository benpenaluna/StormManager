using System.Data.Entity;
using StormManager.Standard.Models;

namespace StormManager.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobTypeStoredProcedure : DbMigration
    {
        public override void Up()
        {
            var modelBuilder = new DbModelBuilder();
            modelBuilder
                .Entity<JobType>()
                .MapToStoredProcedures();
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("JobType_Insert");
            DropStoredProcedure("JobType_Update");
            DropStoredProcedure("JobType_Delete");
        }
    }
}
