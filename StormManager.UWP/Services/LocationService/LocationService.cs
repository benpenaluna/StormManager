using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Services.LocationService
{
    public class LocationService : ILocationService
    {
        public LocationHelper Helper { get; set; }

        public BasicGeoposition Position => this.Helper.Position;

        public async Task<LocationService> StartAsync()
        {
            this.Helper = await new LocationHelper().StartAsync();
            return this;
        }
    }
}
