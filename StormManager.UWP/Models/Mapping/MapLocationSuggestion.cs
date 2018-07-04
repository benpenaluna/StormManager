using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class MapLocationSuggestion : IMapLocationSuggestion
    {
        public IClonedMapLocation MapLocation { get; }

        public MapLocationSuggestion(MapLocation mapLocation)
        {
            MapLocation = ClonedMapLocation.Create(mapLocation);
        }

        public MapLocationSuggestion(IClonedMapLocation clonedMapLocation)
        {
            MapLocation = clonedMapLocation;
        }

        public override string ToString()
        {
            return MapLocation.Address.FormattedAddress;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(MapLocationSuggestion))
            {
                return false;
            }

            return ToString() == obj.ToString();
        }

        protected bool Equals(MapLocationSuggestion other)
        {
            return Equals(MapLocation, other.MapLocation);
        }

        public override int GetHashCode()
        {
            return (MapLocation != null ? MapLocation.GetHashCode() : 0);
        }
    }
}
