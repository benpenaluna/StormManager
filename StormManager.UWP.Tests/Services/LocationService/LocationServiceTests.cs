using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StormManager.Core.Common.Results;
using StormManager.UWP.Common.ExtensionMethods;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StormManager.UWP.Tests.Services.LocationService
{
    [TestClass]
    public class LocationServiceTests
    {
        [Fact]
        public async Task CreateAsync_Test()
        {
            var expectedType = typeof(UWP.Services.LocationService.LocationService);

            var actual = await UWP.Services.LocationService.LocationService.CreateAsync();
            var actualType = actual.GetType();

            Assert.AreEqual(expectedType, actualType);
        }

        [Fact]
        public async Task TryGetCurrentLocationAsync_Test()
        {
            var expectedResultType = typeof(BasicGeoposition);

            var actual = await UWP.Services.LocationService.LocationService.TryGetCurrentLocationAsync();
            var actualType = actual.Result.GetType();

            Assert.AreEqual(expectedResultType, actualType);
        }
    }
}
