using System.Collections.Generic;
using StormManager.UWP.Models;

namespace StormManager.UWP.Core.Repositories
{
    public interface IJobTypeRepository : IRepository<JobType>
    {
        IEnumerable<JobType> GetAllJobTypes();
    }
}
