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
        public async Task LocationHelperInstatiates()
        {
            var service = new Mock<ILocationHelper>();
            service.Setup(x => x.CreateAsync()).Returns(new LocationHelper()
            {
                AccessStatus = GeolocationAccessStatus.Allowed,
                Position = new BasicGeoposition()
            });


            var actual = await new UWP.Services.LocationService.LocationHelper().CreateAsync();

            Assert.NotNull(actual);
        }
    }
}
