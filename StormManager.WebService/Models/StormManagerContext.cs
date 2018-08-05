namespace StormManager.WebService.Models
{
    using System.Data.Entity;

    public partial class StormManagerContext : DbContext
    {
        public StormManagerContext()
            : base("name=StormManagerContext")
        {
        }

        public virtual DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Position)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Member>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);
        }
    }
}
