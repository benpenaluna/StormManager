using Windows.Devices.Geolocation;
using Moq;
using StormManager.UWP.Models.Mapping;

namespace StormManager.UWP.Tests.Models.Mapping
{
    internal class ClonedMapLocationMockFactory
    {
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
            service.Setup(x => x.DisplayName).Returns("Syndey Opera House");
            service.Setup(x => x.Point).Returns(new Geopoint(sydneyOperaHouse));

            return service;
        }
    }
}
