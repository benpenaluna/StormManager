using Newtonsoft.Json;
using StormManager.UWP.Common.Exceptions;
using StormManager.UWP.Services.WebApiService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StormManager.UWP.Tests.Services.WebApiService
{
    public class MockWebApiHelper : IWebApiHelper
    {
        private const string JsonJobTypeSample = "[{\"Id\":1,\"Category\":\"Air Observations and Assessment\",\"SubCategory\":\"\",\"IsUsed\":true,\"NewJobArgb\":-9868951,\"AgingJobArgb\":-16777216},{\"Id\":2,\"Category\":\"Aircraft Incident\",\"SubCategory\":\"Aircraft in Difficulty\",\"IsUsed\":true,\"NewJobArgb\":-9868951,\"AgingJobArgb\":-16777216},{\"Id\":3,\"Category\":\"Aircraft Incident\",\"SubCategory\":\"Insufficient Information to Classify\",\"IsUsed\":true,\"NewJobArgb\":-9868951,\"AgingJobArgb\":-16777216}]";

        public bool MockInternetConnectionExists { get; set; }

        public MockWebApiHelper()
        {
            MockInternetConnectionExists = true;
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string storedProcedureName)
        {
            if (!MockInternetConnectionExists)
                throw new InternetConnectionUnavailableException();

            await Task.Delay(2000);

            return JsonConvert.DeserializeObject<IEnumerable<T>>(JsonJobTypeSample);
        }

        public async Task PutAsync<T>(StoredProcedureAttributes storedProcedureAttributes, T payload)
        {
            await Task.Delay(400);
        }
    }
}
