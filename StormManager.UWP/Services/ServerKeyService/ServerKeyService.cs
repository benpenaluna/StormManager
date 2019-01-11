using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.ServerKeyService
{
    public class ServerKeyService : IServerKeyService
    {
        private IServerKeyHelper Helper { get; set; }

        public string UserId => Helper.UserId;
        public string Password => Helper.Password;

        private ServerKeyService() { }


        public static Task<ServerKeyService> CreateAsync(IServerKeyHelper helper = null)
        {
            var result = new ServerKeyService();
            return result.InitialiseAsync(helper);
        }

        private async Task<ServerKeyService> InitialiseAsync(IServerKeyHelper helper)
        {
            Helper = helper ?? await ServerKeyHelper.CreateAsync();
            return this;
        }
    }
}
