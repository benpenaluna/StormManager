using Plugin.Geolocator.Abstractions;

namespace StormManager.Core.Services.LocationService
{
    interface ILocationService
    {
        Position Position { get; }
    }
}
