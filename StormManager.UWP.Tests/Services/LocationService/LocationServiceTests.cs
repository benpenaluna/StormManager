using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Moq;
using StormManager.UWP.Services.LocationService;
using Xunit;

namespace StormManager.UWP.Tests.Services.LocationService
{
    public class LocationServiceTests
    {
        [Fact]
        public async Task LocationService_Can_Create_New_Instatiate()
        {
            var service = CreateMockLocationHelper();
            var result = await UWP.Services.LocationService.LocationService.CreateAsync(service.Object);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(66.0, -142.0)]
        public async void LocationService_Position_Is_Determined(double latitude, double longitude)
        {
            var expected = new BasicGeoposition(){Latitude = latitude, Longitude = longitude};

            var service = CreateMockLocationHelper(latitude, longitude);
            ILocationService sut = await UWP.Services.LocationService.LocationService.CreateAsync(service.Object);
            var result = sut.Position;

            Assert.Equal(expected, result);
        }

        private static Mock<ILocationHelper> CreateMockLocationHelper(double latitude = 0.0, double longitude = 0.0)
        {
            var service = new Mock<ILocationHelper>();
            service.Setup(x => x.AccessStatus).Returns(GeolocationAccessStatus.Allowed);
            service.Setup(x => x.Position).Returns(new BasicGeoposition()
            {
                Latitude = latitude,
                Longitude = longitude
            });
            return service;
        }
    }
}
