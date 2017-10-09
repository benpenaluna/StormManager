using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Services.LocationService
{
    public class LocationService : ILocationService
    {
        public LocationHelper Helper { get; set; }

        public BasicGeoposition Position => this.Helper.Position;

        public static Task<LocationService> CreateAsync()
        {
            var result = new LocationService();            
            return result.InitialiseAsync();
        }

        private async Task<LocationService> InitialiseAsync()
        {
            this.Helper = await new LocationHelper().CreateAsync();
            return this;
        }
    }
}
