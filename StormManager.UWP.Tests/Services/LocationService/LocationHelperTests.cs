using StormManager.UWP.Services.LocationService;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Xunit;

namespace StormManager.UWP.Tests.Services.LocationService
{
    public class LocationHelperTests
    {
        [Fact]
        public async Task LocationHelper_CanCreateAsyncronously()
        {
            var service = LocationHelperMockFactory.CreateMockLocationHelper(-66.0, 142.0);
            var result = await LocationHelper.CreateAsync(service.Object);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(66.0, -142.0)]
        public async void LocationHelper_CanDeterminePositionFollowingConstruction(double latitude, double longitude)
        {
            var expected = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };

            var service = LocationHelperMockFactory.CreateMockLocationHelper(latitude, longitude);
            var sut = await LocationHelper.CreateAsync(service.Object);
            var result = sut.Position;

            Assert.Equal(expected, result);
        }
    }
}
