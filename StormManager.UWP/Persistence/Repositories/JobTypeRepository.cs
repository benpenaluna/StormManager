﻿using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Models;
using System.Collections.Generic;
using System.Linq;

namespace StormManager.UWP.Persistence.Repositories
{
    public class JobTypeRepository : Repository<JobType>, IJobTypeRepository
    {
        public JobTypeRepository(StormManagerContext context) : base(context) { }

        public IEnumerable<JobType> GetAllJobTypes()
        {
            return StormManagerContext.JobTypes;
        }

        public void AddJobType(JobType jobType)
        {
            StormManagerContext.JobTypes.Add(jobType);
        }

        public void UpdateJobType(JobType jobType)
        {
            var persistedJobType = StormManagerContext.JobTypes.Single(j => j.Id == jobType.Id);
            var jobTypeProperties = jobType.GetType().GetProperties();
            foreach (var prop in jobTypeProperties)
            {
                var jobTypePropValue = prop.GetValue(jobType);
                var persistedJobTypePropValue = prop.GetValue(persistedJobType);
                if (persistedJobTypePropValue.Equals(jobTypePropValue) == false)
                    prop.SetValue(persistedJobType, jobTypePropValue);
            }
        }

        public StormManagerContext StormManagerContext => Context as StormManagerContext;
    }
}
