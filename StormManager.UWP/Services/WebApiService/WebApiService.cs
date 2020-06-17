using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.WebApiService
{
    public partial class WebApiService : IWebApiService
    {
        private IWebApiHelper Helper { get; }

        public WebApiService(string connectionString, IWebApiHelper helper = null)
        {
            Helper = helper ?? new WebApiHelper(connectionString);
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string storedProcedureName)
        {
            try
            {
                return await Helper.GetAsync<T>(storedProcedureName);
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }

            return null;
        }

        public async Task PutAsync<T>(StoredProcedureAttributes storedProcedureAttributes, T payload)
        {
            try
            {
                await Helper.PutAsync(storedProcedureAttributes, payload);
            }
            catch (ArgumentException e)
            {
                Debug.WriteLine("Exception: " + e.Message);
                throw;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
                throw;
            }
        }
    }
}
