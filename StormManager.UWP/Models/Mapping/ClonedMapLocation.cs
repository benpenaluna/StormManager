using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class ClonedMapLocation : IClonedMapLocation
    {
        private readonly MapLocation _mapLocation;

        private readonly IClonedMapLocation _helper;

        private readonly bool _helperProvided;

        public IClonedMapAddress Address => _helperProvided ? _helper.Address : ClonedMapAddress.Create(_mapLocation.Address);

        public string Description => _helperProvided ? _helper.Description : _mapLocation.Description;

        public string DisplayName => _helperProvided ? _helper.DisplayName : _mapLocation.DisplayName;

        public Geopoint Point => _helperProvided ? _helper.Point : _mapLocation.Point;

        private ClonedMapLocation(MapLocation mapLocation)
        {
            _mapLocation = mapLocation;
        }

        private ClonedMapLocation(IClonedMapLocation clonedMapLocation)
        {
            _helper = clonedMapLocation;
            _helperProvided = true;
        }

        public static IClonedMapLocation Create(MapLocation mapLocation)
        {
            return new ClonedMapLocation(mapLocation);
        }

        public static IClonedMapLocation Create(IClonedMapLocation clonedMapLocation)
        {
            return new ClonedMapLocation(clonedMapLocation);
        }
    }
}
