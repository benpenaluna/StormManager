using System;
using System.Threading.Tasks;
using StormManager.UWP.Common.SqlTransactions;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Services.StoredProcedureService
{
    public class StoredProcedureService : IStoredProcedureService
    {
        public IStoredProcedureHelper Helper { get; set; }

        private StoredProcedureService() {}


        public static Task<StoredProcedureService> CreateAsync(IWebApiService webApiService, IStoredProcedureHelper helper = null)
        {
            var result = new StoredProcedureService();
            return result.InitialiseAsync(webApiService, helper);
        }

        private async Task<StoredProcedureService> InitialiseAsync(IWebApiService webApiService, IStoredProcedureHelper helper)
        {
            Helper = helper ?? await StoredProcedureHelper.CreateAsync(webApiService);
            return this;
        }

        public string GetStoredProcedureName(Type entity, SqlTransactionType sqlTransactionType)
        {
            return Helper.GetStoredProcedureName(entity, sqlTransactionType);
        }
    }
}
