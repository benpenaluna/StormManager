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
        public async Task LocationHelper_Instatiates_Asyncronously()
        {
            var service = new Mock<ILocationHelper>();
            service.Setup(x => x.AccessStatus).Returns(GeolocationAccessStatus.Allowed);
            service.Setup(x => x.Position).Returns(new BasicGeoposition()
            {
                Latitude = -66.0,
                Longitude = 157.0
            });

            var result = await new LocationHelper().CreateAsync(service.Object);

            Assert.NotNull(result);
        }
    }
}
