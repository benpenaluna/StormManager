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
        public void ClonedMapAddressBuildingFloor_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingFloor;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingFloor;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressBuildingName_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingName;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingName;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressBuildingRoom_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingRoom;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingRoom;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressBuildingWing_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.BuildingWing;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.BuildingWing;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressContinent_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Continent;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Continent;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressCountry_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Country;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Country;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressCountryCode_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.CountryCode;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.CountryCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressDistrict_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.District;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.District;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressFormattedAddress_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.FormattedAddress;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.FormattedAddress;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressNeighborhood_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Neighborhood;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Neighborhood;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressPostCode_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.PostCode;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.PostCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressRegion_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Region;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Region;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressRegionCode_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.RegionCode;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.RegionCode;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressStreet_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Street;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Street;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressStreetNumber_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.StreetNumber;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.StreetNumber;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ClonedMapAddressTown_ReturnsClonedValue()
        {
            var expected = MockedClonedMapAddress.Town;

            var clonedMapAddress = ClonedMapAddress.Create(MockedClonedMapAddress);
            var actual = clonedMapAddress.Town;

            Assert.Equal(expected, actual);
        }
    }
}
