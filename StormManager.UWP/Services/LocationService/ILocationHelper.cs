using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Services.LocationService
{
    public interface ILocationHelper
    {
        GeolocationAccessStatus AccessStatus { get; }
        BasicGeoposition Position { get; }

        Task<ILocationHelper> CreateAsync();
    }
}
