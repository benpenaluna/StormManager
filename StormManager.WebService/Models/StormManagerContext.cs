using System;
using System.Data.Entity;
using System.Linq;
using StormManager.Standard.Models;

namespace StormManager.WebService.Models
{
    public class StormManagerContext : DbContext
    {
        public StormManagerContext()
            : base("name=StormManagerContext")
        {
        }

        public virtual DbSet<Member> Members { get; set; }
    }
}