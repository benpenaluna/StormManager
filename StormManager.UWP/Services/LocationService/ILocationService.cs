using Windows.Devices.Geolocation;

namespace StormManager.UWP.Services.LocationService
{
    public interface ILocationService
    {
        BasicGeoposition Position { get; }
    }
}
