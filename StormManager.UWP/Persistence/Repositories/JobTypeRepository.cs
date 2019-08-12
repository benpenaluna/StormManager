using System.Collections.Generic;
using System.Linq;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Models;

namespace StormManager.UWP.Persistence.Repositories
{
    public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        public JobTypeRepository(StormManagerContext context) : base(context)
        {
        }

        public IEnumerable<JobType> GetAllJobTypes()
        {
            return StormManagerContext.JobTypes.ToList();
        }

        public StormManagerContext StormManagerContext => Context as StormManagerContext;
    }
}
