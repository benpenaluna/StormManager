using System.Collections.Generic;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.WebApiService
{
    public interface IWebApiService
    {
        Task<IEnumerable<T>> GetAsync<T>(string storedProcedureName);
        Task PutAsync<T>(StoredProcedureAttributes storedProcedureAttributes, T payload);
    }
}
