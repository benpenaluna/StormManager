using MvvmCross.Binding.ExtensionMethods;
using StormManager.UWP.Common.Exceptions;
using Xunit;
using JobType = StormManager.UWP.Models.JobType;

namespace StormManager.UWP.Tests.Services.WebApiService
{
    public class WebApiServiceTests
    {
        private const string ConnectionString = "foo";
        private const string StoredProcedureName = "bar";

        [Fact]
        public void WebApiService_CanInstantiate()
        {
            var result = new UWP.Services.WebApiService.WebApiService(ConnectionString);
            Assert.NotNull(result);
        }

        [Fact]
        public void WebApiService_CanInstantiateWithHelper()
        {
            var helper = new MockWebApiHelper();
            var result = new UWP.Services.WebApiService.WebApiService(ConnectionString, helper);
            Assert.NotNull(result);
        }

        [Fact]
        public void WebApiService_ThrowsExceptionWhenNoConnectivity()
        {
            var helper = new MockWebApiHelper { MockInternetConnectionExists = false };
            var result = new UWP.Services.WebApiService.WebApiService(ConnectionString, helper);
            Assert.ThrowsAsync<InternetConnectionUnavailableException>(async () => await result.GetAsync<JobType>(StoredProcedureName));
        }

        [Fact]
        public async void WebApiService_CanReturnJobTypes()
        {
            var helper = new MockWebApiHelper();

            var result = new UWP.Services.WebApiService.WebApiService(ConnectionString, helper);

            var jobTypes = await result.GetAsync<JobType>(StoredProcedureName);

            Assert.NotNull(jobTypes);
            Assert.True(jobTypes.Count() == 3);
        }
    }
}
