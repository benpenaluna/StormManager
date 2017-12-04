using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using StormManager.Core.Common.Results;

namespace StormManager.UWP.Services.LocationService
{
    public class LocationService : ILocationService
    {
        private ILocationHelper Helper { get; set; }

        public BasicGeoposition Position => Helper.Position;

        private LocationService() { }

        public static Task<LocationService> CreateAsync(ILocationHelper helper = null)
        {
            var result = new LocationService();            
            return result.InitialiseAsync(helper);
        } 

        private async Task<LocationService> InitialiseAsync(ILocationHelper helper)
        {
            Helper = helper ?? await new LocationHelper().CreateAsync();
            return this;
        }

        public static async Task<ITryGetAsyncResult<BasicGeoposition>> TryGetCurrentLocationAsync(ILocationHelper helper = null)
        {
            var locationService = new LocationService { Helper = helper ?? await new LocationHelper().CreateAsync() }; // TODO: LocationHelper being constructed twice. Resolve 
            return new TryGetAsyncResult<BasicGeoposition>(locationService.Helper.AccessStatus == GeolocationAccessStatus.Allowed, 
                                                           locationService.Position);
        }
    }
}
