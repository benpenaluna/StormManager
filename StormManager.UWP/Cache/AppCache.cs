using System.Collections.Generic;

namespace StormManager.UWP.Cache
{
    public static class AppCache
    {
        public static IEnumerable<Models.JobType> JobTypes => App.UnitOfWork.JobTypes.GetAllJobTypes();  // TODO: Remove this, and point application to App.UnitOfWork
    }
}
