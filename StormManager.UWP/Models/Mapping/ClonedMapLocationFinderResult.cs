using System.Collections.Generic;
using System.Linq;
using Windows.Services.Maps;

namespace StormManager.UWP.Models.Mapping
{
    public class ClonedMapLocationFinderResult : IClonedMapLocationFinderResult
    {
        private readonly MapLocationFinderResult _mapLocationinderResult;

        private readonly IClonedMapLocationFinderResult _helper;

        private readonly bool _helperProvided;

        public IReadOnlyList<IClonedMapLocation> Locations => _helperProvided ? _helper.Locations : CloneMapLocationFinderResult();

        public MapLocationFinderStatus Status => _helperProvided ? _helper.Status : _mapLocationinderResult.Status;

        private ClonedMapLocationFinderResult(MapLocationFinderResult mapLocationinderResult)
        {
            _mapLocationinderResult = mapLocationinderResult;
        }

        private ClonedMapLocationFinderResult(IClonedMapLocationFinderResult clonedMapLocationinderResult)
        {
            _helper = clonedMapLocationinderResult;
            _helperProvided = true;
        }

        public static IClonedMapLocationFinderResult Create(MapLocationFinderResult mapLocationinderResult)
        {
            return new ClonedMapLocationFinderResult(mapLocationinderResult);
        }

        public static IClonedMapLocationFinderResult Create(IClonedMapLocationFinderResult clonedMapLocationFinderResult)
        {
            return new ClonedMapLocationFinderResult(clonedMapLocationFinderResult);
        }

        private IReadOnlyList<IClonedMapLocation> CloneMapLocationFinderResult()
        {
            //_mapLocationinderResult.Locations.Select(ClonedMapLocation.Create).ToList;

            return _mapLocationinderResult.Locations.Select(ClonedMapLocation.Create).ToList();
        }
    }
}
