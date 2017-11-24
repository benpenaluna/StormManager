using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Moq;
using StormManager.UWP.Services.LocationService;
using Xunit;

namespace StormManager.UWP.Tests.Services.LocationService
{
    public class LocationHelperTests
    {
        [Fact]
        public async Task LocationHelper_CanCreateAsyncronously()
        {
            var service = LocationHelperMockFactory.CreateMockLocationHelper(-66.0, 142.0);
            var result = await new LocationHelper().CreateAsync(service.Object);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(66.0, -142.0)]
        public async void LocationHelper_CanDeterminePositionOnConstruction(double latitude, double longitude)
        {
            var expected = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };

            var service = LocationHelperMockFactory.CreateMockLocationHelper(latitude, longitude);
            var sut = await new LocationHelper().CreateAsync(service.Object);
            var result = sut.Position;

            Assert.Equal(expected, result);
        }
    }
}
