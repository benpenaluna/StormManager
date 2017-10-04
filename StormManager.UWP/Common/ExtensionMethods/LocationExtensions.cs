using Windows.Devices.Geolocation;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class LocationExtensions
    {
        public static Geopoint ToGeopoint(this BasicGeoposition position)
        {
            return new Geopoint(position);
        }
    }
}
