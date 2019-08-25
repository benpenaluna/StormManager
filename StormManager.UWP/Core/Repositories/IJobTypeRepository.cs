using System.Collections.Generic;
using StormManager.UWP.Models;

namespace StormManager.UWP.Core.Repositories
{
    public interface IJobTypeRepository : IRepository<JobType>
    {
        IEnumerable<JobType> GetAllJobTypes();

        void AddJobType(JobType jobType);
        void UpdateJobType(JobType jobType);
    }
}
