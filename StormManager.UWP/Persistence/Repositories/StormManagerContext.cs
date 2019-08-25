using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using StormManager.Standard.Models.InformationSchema;
using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Models;
using StormManager.UWP.Persistence.ObjectFramework;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.Persistence.Repositories
{
    public class StormManagerContext : RepoContext
    {
        private static readonly string ConnectionSting = ResourceLoaderService.GetResourceValue("ExternalDbConnectionString");
        
        public virtual RepoSet<JobType> JobTypes { get; set; }

        private IEnumerable<Routine> StoredProcedures { get; set; }

        private StormManagerContext() {}

        public static Task<StormManagerContext> CreateAsync()
        {
            var result = new StormManagerContext();
            return result.InitialiseAsync();
        }

        private async Task<StormManagerContext> InitialiseAsync()
        {
            var connectionString = await GetConnectionStringAsync();
            InitialiseWebApiService(connectionString); // TODO: Exception handling of unable to populate connection string

            var routines = InitialiseStoredProceduresAsync();
            await Task.WhenAll(routines);

            JobTypes = await InitialiseRepoSet<JobType>(ResourceLoaderService.GetResourceValue("StormManagerContext_GetAllJobTypes"));

            return this;
        }

        private static async Task<string> GetConnectionStringAsync()
        {
            Services.ServerKeyService.IServerKeyService service = await Services.ServerKeyService.ServerKeyService.CreateAsync();
            return string.Format(ConnectionSting, service.UserId, service.Password);
        }

        private async Task InitialiseStoredProceduresAsync()
        {
            var routines = await WebApiService.GetAsync<Routine>(ResourceLoaderService.GetResourceValue("StormManagerContext_GetAll_StoredProcedures"));
            StoredProcedures = routines;
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
