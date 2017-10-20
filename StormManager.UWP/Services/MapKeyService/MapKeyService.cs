using System;
using System.Threading.Tasks;

namespace StormManager.UWP.Services.MapKeyService
{
    public sealed class MapKeyService : IMapKeyService
    {
        public MapKeyHelper Helper { get; set; }

        public string Key => this.Helper.Key;

        public static Task<MapKeyService> CreateAsync()
        {
            var result = new MapKeyService();
            return result.InitialiseAsync();
        }

        private async Task<MapKeyService> InitialiseAsync()
        {
            this.Helper = await new MapKeyHelper().CreateAsync();
            return this;
        }
    }
}
