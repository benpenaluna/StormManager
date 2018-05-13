using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class ClonedMapLocation : IClonedMapLocation
    {
        private readonly MapLocation _mapLocation;

        private readonly IClonedMapLocation _helper;

        public IClonedMapAddress Address => _helper.Address ?? ClonedMapAddress.Create(_mapLocation.Address);

        public string Description => _helper.Description ?? _mapLocation.Description;

        public string DisplayName => _helper.DisplayName ?? _mapLocation.DisplayName;

        public Geopoint Point => _helper.Point ?? _mapLocation.Point;

        private ClonedMapLocation(MapLocation mapLocation)
        {
            _mapLocation = mapLocation;
        }

        private ClonedMapLocation(IClonedMapLocation clonedMapLocation)
        {
            _helper = clonedMapLocation;
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
