using System.Collections.Generic;
using System.Threading.Tasks;
using StormManager.Standard.Models;
using StormManager.UWP.Services.WebApiService;

namespace StormManager.UWP.Cache
{
    public static class AppCache
    {
        private static IWebApiService _webApiService = new WebApiService();

        public static IEnumerable<Member> AllMembers { get; set; }

        public static async Task GetMembersAsync()
        {
            AllMembers = await _webApiService.GetAsync<Member>("GetAllMembers");
        }
    }
}
