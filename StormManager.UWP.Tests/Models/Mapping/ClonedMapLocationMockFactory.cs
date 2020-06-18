using Moq;
using StormManager.UWP.Models.Mapping;
using Windows.Devices.Geolocation;

namespace StormManager.UWP.Tests.Models.Mapping
{
    internal class ClonedMapLocationMockFactory
    {
        public static readonly string ClonedDisplayName = "Sydney Opera House";

        public static Mock<IClonedMapLocation> CreateMockClonedMapLocation()
        {
            var mockAddress = ClonedMapAddressMockFactory.CreateMockClonedMapAddress().Object;
            var sydneyOperaHouse = new BasicGeoposition()
            {
                Latitude = -33.856660,
                Longitude = 151.215300
            };

            var service = new Mock<IClonedMapLocation>();
            service.Setup(x => x.Address).Returns(mockAddress);
            service.Setup(x => x.Description).Returns("The Sydney Opera House is a multi-venue performing arts centre in Sydney, New South Wales, Australia.");
            service.Setup(x => x.DisplayName).Returns(ClonedDisplayName);
            service.Setup(x => x.Point).Returns(new Geopoint(sydneyOperaHouse));

            return service;
        }
    }
}
