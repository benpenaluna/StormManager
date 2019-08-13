using System.Threading.Tasks;
using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Models;

namespace StormManager.UWP.Persistence.Repositories
{
    public class StormManagerContext : RepoContext
    {
        private static readonly string ConnectionSting = "Server=tcp:stormmanagerserver.database.windows.net,1433;Initial Catalog=StormManager;Persist Security Info=False;User ID={0};Password={1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;App=EntityFramework";

        public virtual RepoSet<JobType> JobTypes { get; set; }

        private StormManagerContext() : base(ConnectionSting)
        {
        }

        public static Task<StormManagerContext> CreateAsync()
        {
            var result = new StormManagerContext();
            return result.InitialiseAsync();
        }

        private async Task<StormManagerContext> InitialiseAsync()
        {
            await InitialiseJobTypes();
            
            return this;
        }

        private async Task InitialiseJobTypes()
        {
            try
            {
                var jobTypes = await _webApiService.GetAsync<JobType>("GetAllJobTypes");
                JobTypes = jobTypes != null ? new RepoSet<JobType>(jobTypes): new RepoSet<JobType>();
            }
            catch (InternetConnectionUnavailableException)
            {
                JobTypes = new RepoSet<JobType>();
            }
        }
    }
}
