using Moq;
using StormManager.UWP.Models.Mapping;
using System.Collections.Generic;
using Windows.Services.Maps;

namespace StormManager.UWP.Tests.Models.Mapping
{
    internal static class ClonedMapLocationFinderResultMockFactory
    {
        public static Mock<IClonedMapLocationFinderResult> CreateMockClonedMapLocation()
        {
            var clonedMapLocation = ClonedMapLocationMockFactory.CreateMockClonedMapLocation().Object;
            var mapLocations = new List<ClonedMapLocation>
            {
                ClonedMapLocation.Create(clonedMapLocation) as ClonedMapLocation
            };

            var service = new Mock<IClonedMapLocationFinderResult>();
            service.Setup(x => x.Locations).Returns(mapLocations);
            service.Setup(x => x.Status).Returns(MapLocationFinderStatus.Success);

            return service;
        }
    }
}
