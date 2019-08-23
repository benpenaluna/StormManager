using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using StormManager.Standard.Models;

namespace StormManager.WebService.Models
{
    public class StormManagerContext : DbContext
    {
        public StormManagerContext() : base("name=StormManagerContext") {}

        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobType>()
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<JobType>()
                .Property(x => x.UpdatedBy)
                .IsRequired()
                .HasMaxLength(8);
        }
    }
}