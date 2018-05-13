using Moq;
using StormManager.UWP.Models.Mapping;

namespace StormManager.UWP.Tests.Models.Mapping
{
    internal static class ClonedMapAddressMockFactory
    {
        public static Mock<IClonedMapAddress> CreateMockClonedMapAddress()
        {
            var service = new Mock<IClonedMapAddress>();
            service.Setup(x => x.BuildingFloor).Returns("5");
            service.Setup(x => x.BuildingName).Returns("Sydney Myer Music Bowl");
            service.Setup(x => x.BuildingRoom).Returns("Disco Room");
            service.Setup(x => x.BuildingWing).Returns("East");
            service.Setup(x => x.Continent).Returns("Australasia");
            service.Setup(x => x.Country).Returns("Australia");
            service.Setup(x => x.CountryCode).Returns("+61");
            service.Setup(x => x.District).Returns("Hume");
            service.Setup(x => x.FormattedAddress).Returns("12 Madeup St, MockTown, MockState, Australia");
            service.Setup(x => x.Neighborhood).Returns("Madeup St");
            service.Setup(x => x.PostCode).Returns("0000");
            service.Setup(x => x.Region).Returns("My State");
            service.Setup(x => x.RegionCode).Returns("3");
            service.Setup(x => x.Street).Returns("Madeup");
            service.Setup(x => x.StreetNumber).Returns("12");
            service.Setup(x => x.Town).Returns("Sydney");

            return service;
        }
    }
}
