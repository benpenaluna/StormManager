using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Common.SqlTransactions;
using StormManager.UWP.Models;
using StormManager.UWP.Persistence.ObjectFramework;
using StormManager.UWP.Services.ResourceLoaderService;
using StormManager.UWP.Services.StoredProcedureService;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace StormManager.UWP.Persistence.Repositories
{
    public class StormManagerContext : RepoContext
    {
        private static readonly string ConnectionSting = ResourceLoaderService.GetResourceValue("ExternalDbConnectionString");

        public virtual RepoSet<JobType> JobTypes { get; set; }

        private StoredProcedureService StoredProcedureService { get; set; }

        private StormManagerContext() { }

        public static Task<StormManagerContext> CreateAsync()
        {
            var result = new StormManagerContext();
            return result.InitialiseAsync();
        }

        private async Task<StormManagerContext> InitialiseAsync()
        {
            var connectionString = await GetConnectionStringAsync();
            InitialiseWebApiService(connectionString); // TODO: Exception handling of unable to populate connection string

            var service = InitialiseStoredProcedureService();
            await Task.WhenAll(service);

            JobTypes = await InitialiseRepoSet<JobType>(ResourceLoaderService.GetResourceValue("StormManagerContext_GetAllJobTypes"));

            return this;
        }

        private static async Task<string> GetConnectionStringAsync()
        {
            Services.ServerKeyService.IServerKeyService service = await Services.ServerKeyService.ServerKeyService.CreateAsync();
            return string.Format(ConnectionSting, service.UserId, service.Password);
        }

        private async Task InitialiseStoredProcedureService()
        {
            StoredProcedureService = await StoredProcedureService.CreateAsync(WebApiService);
        }

        private async Task<RepoSet<TEntity>> InitialiseRepoSet<TEntity>(string storedProcedureName) where TEntity : class, INotifyPropertyChanged
        {
            IEnumerable<TEntity> entityCollection;
            try
            {
                entityCollection = await WebApiService.GetAsync<TEntity>(storedProcedureName);
            }
            catch (InternetConnectionUnavailableException)
            {
                return InitialiseFromLocalDatabase<TEntity>();
            }

            if (entityCollection == null)
                return InitialiseFromLocalDatabase<TEntity>();

            return new RepoSet<TEntity>(entityCollection)
            {
                AddStoredProcedureName = StoredProcedureService.GetStoredProcedureName(typeof(TEntity), SqlTransactionType.Insertion),
                UpdateStoredProcedureName = StoredProcedureService.GetStoredProcedureName(typeof(TEntity), SqlTransactionType.Update),
                DeleteStoredProcedureName = StoredProcedureService.GetStoredProcedureName(typeof(TEntity), SqlTransactionType.Deletion)
            };

        }

        private static RepoSet<TEntity> InitialiseFromLocalDatabase<TEntity>() where TEntity : class, INotifyPropertyChanged
        {
            return new RepoSet<TEntity>();

            // TODO: Load data from Local SqlLite database once configured
            // TODO: Initialise StoredProcedureNames
        }

        public override async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(JobTypes); // TODO: Determine what to do when there are more RepoSets
        }

        public override RepoSet<TEntity> Set<TEntity>()
        {
            var myProperties = GetType().GetProperties();
            foreach (var prop in myProperties)
            {
                var propType = prop.PropertyType;
                var targetType = typeof(RepoSet<TEntity>);
                if (propType == targetType)
                    return prop.GetValue(this) as RepoSet<TEntity>;
            }

            return new RepoSet<TEntity>(); // TODO: Remove this, as it is only here to satisfy the compiler
        }
    }
}
