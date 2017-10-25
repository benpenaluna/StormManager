using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using StormManager.Core.Common.Results;

namespace StormManager.UWP.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private LocationHelper Helper { get; set; }

        public BasicGeoposition Position => Helper.Position;

        public static Task<LocationService> CreateAsync()
        {
            var result = new LocationService();            
            return result.InitialiseAsync();
        }

        public static async Task<ITryGetAsyncResult<BasicGeoposition>> TryGetCurrentLocationAsync()
        {
            var locationService = new LocationService {Helper = await new LocationHelper().CreateAsync()};
            return (locationService.Helper.AccessStatus == GeolocationAccessStatus.Allowed)
                ? new TryGetAsyncResult<BasicGeoposition>(true, locationService.Position)
                : new TryGetAsyncResult<BasicGeoposition>(false, locationService.Position);
        }

        private async Task<LocationService> InitialiseAsync()
        {
            Helper = await new LocationHelper().CreateAsync();
            return this;
        }
    }
}
