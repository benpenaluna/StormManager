using System.Data.Entity;
using StormManager.UWP.Models;
using StormManager.UWP.Persistence.EntityConfigurations;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Persistence.Repositories
{
    public class StormManagerContext : DbContext
    {
        public virtual DbSet<JobType> JobTypes { get; set; }
        
        //public StormManagerContext(string ConnectionString) : base(Database.DefaultConnectionFactory.CreateConnection(ConnectionString), true)
        //{
        //    Configuration.LazyLoadingEnabled = false;
        //}

        public StormManagerContext(string ConnectionString) : base(ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JobTypeConfiguration());
        }
    }
}
