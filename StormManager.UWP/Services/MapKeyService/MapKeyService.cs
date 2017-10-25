using System.Threading.Tasks;

namespace StormManager.UWP.Services.MapKeyService
{
    public sealed class MapKeyService : IMapKeyService
    {
        public MapKeyHelper Helper { get; set; }

        public string Key => Helper.Key;

        public static Task<MapKeyService> InstanceAsync()
        {
            var result = new MapKeyService();
            return result.InitialiseAsync();
        }

        private async Task<MapKeyService> InitialiseAsync()
        {
            Helper = await new MapKeyHelper().CreateAsync();
            return this;
        }
    }
}
