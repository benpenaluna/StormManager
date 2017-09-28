using System.Threading.Tasks;

namespace StormManager.UWP.Services.MapKeyService
{
    public class MapKeyService : IMapKeyService
    {
        public MapKeyHelper Helper { get; set; }

        public string Key => this.Helper.Key;

        public async Task<MapKeyService> StartAsync()
        {
            this.Helper = await new MapKeyHelper().StartAsync();
            return this;
        }
    }
}
