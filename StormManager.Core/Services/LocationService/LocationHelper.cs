using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;

namespace StormManager.Core.Services.LocationService
{
    public class LocationHelper
    {
        public Position Position { get; private set; }

        public async Task<LocationHelper> StartAsync()
        {
            Position = await GetPositionAsync();
            return this;
        }

        private static async Task<Position> GetPositionAsync()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100;

            return await locator.GetPositionAsync(new TimeSpan(10000));
        }
    }
}
