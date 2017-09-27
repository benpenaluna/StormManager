using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

namespace StormManager.Core.Services.LocationService
{
    public class LocationService : ILocationService
    {
        public LocationHelper Helper { get; set; }

        public Position Position => this.Helper.Position;

        public async Task<LocationService> StartAsync()
        {
            this.Helper = await new LocationHelper().StartAsync();
            return this;
        }
    }
}
