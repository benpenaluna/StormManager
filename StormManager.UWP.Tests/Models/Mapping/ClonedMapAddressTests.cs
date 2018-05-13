using StormManager.UWP.Models.Mapping;
using Xunit;

namespace StormManager.UWP.Tests.Models.Mapping
{
    public class ClonedMapAddressTests
    {
        private static readonly IClonedMapAddress MockedClonedMapAddress = ClonedMapAddressMockFactory.CreateMockClonedMapAddress().Object;

        [Fact]
        public void ClonedMapAddress_CanCreate()
        {
            var result = ClonedMapAddress.Create(MockedClonedMapAddress);
            Assert.NotNull(result);
        }

        [Fact]
        public void ClonedMapAddresBuildingFloor_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingFloor;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingFloor;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresBuildingName_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingName;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingName;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresBuildingRoom_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingRoom;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingRoom;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresBuildingWing_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingWing;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingWing;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresContinent_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Continent;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Continent;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresCountry_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Country;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Country;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresCountryCode_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.CountryCode;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.CountryCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresDistrict_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.District;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.District;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresFormattedAddress_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.FormattedAddress;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.FormattedAddress;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresNeighborhood_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Neighborhood;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Neighborhood;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresPostCode_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.PostCode;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.PostCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresRegion_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Region;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Region;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresRegionCode_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.RegionCode;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.RegionCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresStreet_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Street;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Street;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresStreetNumber_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.StreetNumber;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.StreetNumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddresTown_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Town;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Town;

            Assert.Equal(expected, actual);
        }
    }
}
