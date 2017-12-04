using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class MapLocationSuggestion : IMapLocationSuggestion
    {
        public MapLocation MapLocation { get; }

        public MapLocationSuggestion(MapLocation mapLocation)
        {
            MapLocation = mapLocation;
        }

        public override string ToString()
        {
            return MapLocation.Address.FormattedAddress;
        }
    }
}
