using Moq;
using StormManager.UWP.Models.Mapping;

namespace StormManager.UWP.Tests.Models.Mapping
{
    internal static class MapLocationSuggestionMockFactory
    {
        public static Mock<IMapLocationSuggestion> CreateMockMapLocationSuggestion()
        {
            var mockMapLocation = ClonedMapLocationMockFactory.CreateMockClonedMapLocation();

            var service = new Mock<IMapLocationSuggestion>();
            service.Setup(x => x.MapLocation).Returns(mockMapLocation.Object);

            return service;
        }
    }
}
