﻿using StormManager.Core.Common.Results;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

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
            Helper = helper ?? await LocationHelper.CreateAsync();
            return this;
        }

        public static async Task<ITryGetAsyncResult<BasicGeoposition>> TryGetCurrentLocationAsync(ILocationHelper helper = null)
        {
            var locationService = new LocationService { Helper = helper ?? await LocationHelper.CreateAsync() };
            return new TryGetAsyncResult<BasicGeoposition>(locationService.Helper.AccessStatus == GeolocationAccessStatus.Allowed,
                                                           locationService.Position);
        }
    }
}
