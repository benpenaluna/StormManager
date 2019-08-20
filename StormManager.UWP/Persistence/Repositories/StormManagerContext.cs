using System.ComponentModel;
using System.Threading.Tasks;
using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Models;
using StormManager.UWP.Persistence.ObjectFramework;
using StormManager.UWP.Services.ResourceLoaderService;

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

            JobTypes = await InitialiseRepoSet<JobType>(ResourceLoaderService.GetResourceValue("StormManagerContext.GetAllJobTypes"));
            return this;
        }

        private static async Task<string> GetConnectionStringAsync()
        {
            Services.ServerKeyService.IServerKeyService service = await Services.ServerKeyService.ServerKeyService.CreateAsync();
            return string.Format(ConnectionSting, service.UserId, service.Password);
        }

        private async Task<RepoSet<TEntity>> InitialiseRepoSet<TEntity>(string storedProcedureName) where TEntity : class, INotifyPropertyChanged
        {
            try
            {
                var entityCollection = await WebApiService.GetAsync<TEntity>(storedProcedureName);  
                return entityCollection != null ? new RepoSet<TEntity>(entityCollection): new RepoSet<TEntity>();
            }
            catch (InternetConnectionUnavailableException)
            {
                return new RepoSet<TEntity>(); // TODO: Load data from Local SqlLite database once configured
            }
        }
    }
}
