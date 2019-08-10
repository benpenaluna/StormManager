using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StormManager.UWP.Models;

namespace StormManager.UWP.Persistence.EntityConfigurations
{
    public class JobTypeConfiguration : EntityTypeConfiguration<JobType>
    {
        public JobTypeConfiguration()
        {
            Property(c => c.Id)
                .IsRequired();

            Property(c => c.IsUsed)
                .IsRequired();

            Property(c => c.NewJobArgb)
                .IsRequired();

            Property(c => c.AgingJobArgb)
                .IsRequired();
        }
    }
}
