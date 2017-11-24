using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Moq;
using StormManager.Core.Common.Results;
using StormManager.UWP.Services.LocationService;
using Xunit;

namespace StormManager.UWP.Tests.Services.LocationService
{
    public class LocationServiceTests
    {
        [Fact]
        public async Task LocationService_CanCreateAsyncronously()
        {
            var service = LocationHelperMockFactory.CreateMockLocationHelper();
            var result = await UWP.Services.LocationService.LocationService.CreateAsync(service.Object);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(66.0, -142.0)]
        public async void LocationService_CanDeterminePositionOnConstruction(double latitude, double longitude)
        {
            var expected = new BasicGeoposition(){Latitude = latitude, Longitude = longitude};

            var service = LocationHelperMockFactory.CreateMockLocationHelper(latitude, longitude);
            ILocationService sut = await UWP.Services.LocationService.LocationService.CreateAsync(service.Object);
            var result = sut.Position;

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(66.0, -142.0)]
        public async void LocationService_CanDeterminePositionStatically(double latitude, double longitude)
        {
            var expected = new TryGetAsyncResult<BasicGeoposition>(true, new BasicGeoposition() { Latitude = latitude, Longitude = longitude });

            var service = LocationHelperMockFactory.CreateMockLocationHelper(latitude, longitude);
            var sut = await UWP.Services.LocationService.LocationService.TryGetCurrentLocationAsync(service.Object);

            Assert.Equal(expected.Result, sut.Result);
        }
    }
}
