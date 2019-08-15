using System.Threading.Tasks;
using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Models;

namespace StormManager.UWP.Persistence.Repositories
{
    public class StormManagerContext : RepoContext
    {
        private static readonly string ConnectionSting = "Server=tcp:stormmanagerserver.database.windows.net,1433;Initial Catalog=StormManager;Persist Security Info=False;User ID={0};Password={1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;App=EntityFramework";

        public virtual RepoSet<JobType> JobTypes { get; set; }

        private StormManagerContext()
        {
        }

        public static Task<StormManagerContext> CreateAsync()
        {
            var result = new StormManagerContext();
            return result.InitialiseAsync();
        }

        private async Task<StormManagerContext> InitialiseAsync()
        {
            var connectionString = await GetConnectionStringAsync();
            InitialiseWebApiService(connectionString); // TODO: Exception handling of unable to populate connection string

            await InitialiseJobTypes();
            return this;
        }

        private static async Task<string> GetConnectionStringAsync()
        {
            Services.ServerKeyService.IServerKeyService service = await Services.ServerKeyService.ServerKeyService.CreateAsync();
            return string.Format(ConnectionSting, service.UserId, service.Password);
        }

        private async Task InitialiseJobTypes()
        {
            try
            {
                var jobTypes = await WebApiService.GetAsync<JobType>("GetAllJobTypes");  // TODO: Remove literal string
                JobTypes = jobTypes != null ? new RepoSet<JobType>(jobTypes): new RepoSet<JobType>();
            }
            catch (InternetConnectionUnavailableException)
            {
                JobTypes = new RepoSet<JobType>(); // TODO: Load data from Local SqlLite database once configured
            }
        }
    }
}
