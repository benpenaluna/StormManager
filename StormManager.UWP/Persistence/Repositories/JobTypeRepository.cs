using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Models;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Persistence.Repositories
{
    public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        public async Task<IEnumerable<JobType>> GetAllJobTypesAsync()
        {
            return await WebApiService.GetAsync<JobType>("GetAllJobTypes"); // TODO: Remove literal string
        }
    }
}
