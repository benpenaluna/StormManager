using System.Collections.Generic;
using System.Threading.Tasks;
using StormManager.UWP.Models;

namespace StormManager.UWP.Core.Repositories
{
    public interface IJobTypeRepository : IRepository<JobType>
    {
        Task<IEnumerable<JobType>> GetAllJobTypesAsync();
    }
}
