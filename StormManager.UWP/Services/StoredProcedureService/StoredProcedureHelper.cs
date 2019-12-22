using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StormManager.Standard.Models.InformationSchema;
using StormManager.UWP.Persistence.ObjectFramework;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public class StoredProcedureHelper : IStoredProcedureHelper
    {
        private IWebApiService WebApiService { get; }

        public IEnumerable<Routine> StoredProcedures { get; set; }

        private StoredProcedureHelper(IWebApiService webApiService)
        {
            WebApiService = webApiService;
        }

        public static Task<StoredProcedureHelper> CreateAsync(IWebApiService webApiService)
        {
            var result = new StoredProcedureHelper(webApiService);
            return result.InitialiseAsync();
        }

        private async Task<StoredProcedureHelper> InitialiseAsync()
        {
            var routines = await WebApiService.GetAsync<Routine>(ResourceLoaderService.ResourceLoaderService.GetResourceValue("StormManagerContext_GetAll_StoredProcedures"));
            StoredProcedures = routines;
            return this;
        }

        public string GetStoredProcedureName(Type entity, DataManipulation dataManipulationType)
        {
            // TODO: Determine what to do here if the request information is not contained in StoredProcedures
            try
            {
                return StoredProcedures.First(x => x.TableName == entity.Name &&
                                                   x.TransactionType == dataManipulationType.ToString())?.StoredProcedureName;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
