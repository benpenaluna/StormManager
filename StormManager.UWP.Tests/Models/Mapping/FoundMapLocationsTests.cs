using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using StormManager.UWP.Models.Mapping;
using Xunit;

namespace StormManager.UWP.Tests.Models.Mapping
{
    public class FoundMapLocationsTests
    {
        [Fact]
        public void CanInstantiate()
        {
            var result = FoundMapLocations.Create();

            Assert.NotNull(result);
            Assert.NotNull(result.Locations);
        }

        [Fact]
        public void CanUpdateLocations()
        {
            var mockLocations = ClonedMapLocationFinderResultMockFactory.CreateMockClonedMapLocation().Object;

            var sut = FoundMapLocations.Create();
            sut.UpdateLocations(mockLocations);

            var expected = mockLocations.Locations.Select(x => new MapLocationSuggestion(x)).ToList();
            foreach (var result in sut.Locations)
            {
                Assert.Contains(result, expected);
            }
        }

        [Fact]
        public void IsLocationsListEmpty_ReturnsTrueWhenEmpty()
        {
            const bool expected = true;

            var sut = FoundMapLocations.Create();
            var result = sut.IsLocationsListEmpty;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsLocationsListEmpty_ReturnsFalseWithItems()
        {
            const bool expected = false;

            var sut = PopulatedFoundMapLocations();
            var result = sut.IsLocationsListEmpty;

            Assert.Equal(expected, result);
        }

        private static IFoundMapLocations PopulatedFoundMapLocations()
        {
            var mockLocations = ClonedMapLocationFinderResultMockFactory.CreateMockClonedMapLocation().Object;
            var sut = FoundMapLocations.Create();
            sut.UpdateLocations(mockLocations);
            return sut;
        }

        [Fact]
        public void Locations_CanGetLocations()
        {
            var sut = PopulatedFoundMapLocations();

            Assert.NotNull(sut.Locations);
        }

        [Fact]
        public void LastLocation_CanRetrieve()
        {
            var expected = ClonedMapLocationMockFactory.ClonedDisplayName;
            var userInput = expected.Length >= 13 ? expected.Substring(0, 13) : expected;

            var sut = PopulatedFoundMapLocations();
            var result = sut.LastLocation(userInput).DisplayName;

            Assert.Equal(expected, result);
        }
    }
}
