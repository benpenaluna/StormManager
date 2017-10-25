using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using StormManager.Core.Common.Results;
using StormManager.UWP.Common.ExtensionMethods;
using Xunit;

namespace StormManager.UWP.Tests.Services.LocationService
{
    public class LocationServiceTests
    {
        [Fact]
        public async Task LocationServiceInstatiates()
        {
            var actual = await UWP.Services.LocationService.LocationService.CreateAsync();

            Assert.NotNull(actual);
        }

        [Fact]
        public async Task TryGetCurrentLocationAsync_Test()
        {
            var expectedResultType = typeof(BasicGeoposition);

            var actual = await UWP.Services.LocationService.LocationService.TryGetCurrentLocationAsync();
            var actualType = actual.Result.GetType();

            Assert.Equal(expectedResultType, actualType);
        }
    }
}
