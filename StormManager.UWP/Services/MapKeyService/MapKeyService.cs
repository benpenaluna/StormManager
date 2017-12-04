using System.Threading.Tasks;

namespace StormManager.UWP.Services.MapKeyService
{
    public sealed class MapKeyService : IMapKeyService
    {
        private IMapKeyHelper Helper { get; set; }

        public string Key => Helper.Key;

        private MapKeyService() { }

        public static Task<MapKeyService> CreateAsync(IMapKeyHelper helper = null)
        {
            var result = new MapKeyService();
            return result.InitialiseAsync(helper);
        }

        private async Task<MapKeyService> InitialiseAsync(IMapKeyHelper helper)
        {
            Helper = helper ?? await new MapKeyHelper().CreateAsync(); // TODO: The object is being constructed twice. Resolve
            return this;
        }
    }
}
