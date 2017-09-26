using Plugin.Geolocator.Abstractions;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class LocationExtensions
    {
        public static Geopoint ToGeopoint(this Position position)
        {
            var basicGeoPosition = new BasicGeoposition()
            {
                Latitude = position.Latitude,
                Longitude = position.Longitude
            };

            return new Geopoint(basicGeoPosition);
        }
    }
}
