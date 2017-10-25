using Windows.Devices.Geolocation;

namespace StormManager.UWP.Services.LocationService
{
    internal interface ILocationService
    {
        BasicGeoposition Position { get; }
    }
}
