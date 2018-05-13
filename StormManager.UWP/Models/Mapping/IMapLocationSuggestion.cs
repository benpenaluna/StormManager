    using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public interface IMapLocationSuggestion
    {
        MapLocation MapLocation { get; }
    }
}