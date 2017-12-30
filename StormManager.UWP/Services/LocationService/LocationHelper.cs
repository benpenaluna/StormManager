using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using StormManager.UWP.Common.Exceptions;

namespace StormManager.UWP.Services.LocationService
{
    public class LocationHelper : ILocationHelper
    {
        public GeolocationAccessStatus AccessStatus { get; private set; }

        public BasicGeoposition Position { get; private set; }

        private LocationHelper() { }
        
        public static Task<ILocationHelper> CreateAsync(ILocationHelper helper = null)
        {
            var result = new LocationHelper();
            return result.InitialiseAsync(helper);
        }

        private async Task<ILocationHelper> InitialiseAsync(ILocationHelper helper = null)
        {
            if (helper == null)
            {
                await TryDetermineActualLocation();
            }
            else
            {
                SetProvidedAcessStatusAndPosition(helper);
            }

            return this;
        }

        private async Task TryDetermineActualLocation()
        {
            try
            {
                var geoposition = await GetPositionAsync();
                SetReturnProperties(geoposition, GeolocationAccessStatus.Allowed);
            }
            catch (GeolocationAccessDeniedException)
            {
                SetReturnProperties(CreateBasicGeoposition(0.0, 0.0), GeolocationAccessStatus.Denied);
            }
        }

        private static async Task<BasicGeoposition> GetPositionAsync()
        {
            var access = await Geolocator.RequestAccessAsync();
            if (access != GeolocationAccessStatus.Allowed)
            {
                throw new GeolocationAccessDeniedException();
            }

            try
            {
                var locator = new Geolocator {DesiredAccuracyInMeters = 0};
                var position = await locator.GetGeopositionAsync();
                return CreateBasicGeoposition(position.Coordinate.Point.Position.Latitude,
                    position.Coordinate.Point.Position.Longitude);
            }
            catch
            {
                throw new GeolocationAccessDeniedException();
            }
        }

        private static BasicGeoposition CreateBasicGeoposition(double latitude, double longitude)
        {
            return new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            };
        }

        private void SetReturnProperties(BasicGeoposition geoposition, GeolocationAccessStatus accessStatus)
        {
            Position = geoposition;
            AccessStatus = accessStatus;
        }

        private void SetProvidedAcessStatusAndPosition(ILocationHelper helper)
        {
            AccessStatus = helper.AccessStatus;
            Position = helper.Position;
        }
    }
}
