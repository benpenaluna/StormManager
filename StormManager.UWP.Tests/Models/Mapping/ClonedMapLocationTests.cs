using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using StormManager.UWP.Models.Mapping;
using Xunit;

namespace StormManager.UWP.Tests.Models.Mapping
{
    public class ClonedMapLocationTests
    {
        private static readonly IClonedMapLocation MockedClonedMapLocation = ClonedMapLocationMockFactory.CreateMockClonedMapLocation().Object;

        [Fact]
        public void ClonedMapLocation_CanCreatePropsNotNull()
        {
            var result = ClonedMapLocation.Create(MockedClonedMapLocation);
            Assert.NotNull(result);
            Assert.NotNull(result.Address);
            Assert.NotNull(result.Description);
            Assert.NotNull(result.DisplayName);
            Assert.NotNull(result.Point);
        }

        [Fact]
        public void ClonedMapLocation_CheckAddressEquality()
        {
            var expected = MockedClonedMapLocation.Address;

            var result = ClonedMapLocation.Create(MockedClonedMapLocation).Address;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ClonedMapLocation_CheckDescriptionEquality()
        {
            var expected = MockedClonedMapLocation.Description;

            var result = ClonedMapLocation.Create(MockedClonedMapLocation).Description;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ClonedMapLocation_CheckDisplayNameEquality()
        {
            var expected = MockedClonedMapLocation.DisplayName;

            var result = ClonedMapLocation.Create(MockedClonedMapLocation).DisplayName;

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ClonedMapLocation_CheckPointEquality()
        {
            var expected = MockedClonedMapLocation.Point;

            var result = ClonedMapLocation.Create(MockedClonedMapLocation).Point;

            Assert.Equal(expected, result);
        }
    }
}
