using System.Collections.Generic;
using System.Threading.Tasks;
using StormManager.Standard.Models;
using StormManager.UWP.Core.Repositories;
using StormManager.UWP.Persistence.Repositories;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Cache
{
    public static class AppCache
    {
        // DRY: Copied for WebApiService class
        //private static readonly string ConnectionSting = "Server=tcp:stormmanagerserver.database.windows.net,1433;Initial Catalog=StormManager;Persist Security Info=False;User ID={0};Password={1};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;App=EntityFramework";

        //private static IWebApiService _webApiService = new WebApiService();

        //public static IEnumerable<Member> AllMembers { get; set; }
        public static IEnumerable<Models.JobType> JobTypes { get; set; }
        //public static IEnumerable<Models.JobType> JobTypes => WebApiService.JobTypes;

        //public static StormManagerContext WebApiService { get; set; }

        //public static async Task GetMembersAsync()
        //{
        //    AllMembers = await _webApiService.GetAsync<Member>("GetAllMembers");
        //}

        //public static async Task GetJobTypesAsync()
        //{
        //    JobTypes = await _webApiService.GetAsync<Models.JobType>("GetAllJobTypes");
        //}

        // DRY: Copied from WebApiService class 
        //private static async Task<string> GetConnectionString()
        //{
        //    Services.ServerKeyService.IServerKeyService service = await Services.ServerKeyService.ServerKeyService.CreateAsync();
        //    return string.Format(ConnectionSting, service.UserId, service.Password);
        //}

        public static async Task InitialiseCollections()
        {
            IJobTypeRepository jobTypesRepo = new JobTypeRepository();
            JobTypes = await jobTypesRepo.GetAllJobTypesAsync();
        } 
    }
}
