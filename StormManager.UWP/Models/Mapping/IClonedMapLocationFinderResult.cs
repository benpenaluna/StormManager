using System.Collections.Generic;
using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public interface IClonedMapLocationFinderResult
    {
        IReadOnlyList<IClonedMapLocation> Locations { get; }
        MapLocationFinderStatus Status { get; }
    }
}
