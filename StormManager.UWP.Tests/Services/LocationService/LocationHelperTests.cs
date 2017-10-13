using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StormManager.UWP.Tests.Services.LocationService
{
    [TestClass]
    public class LocationHelperTests
    {
        [Fact]
        public async Task CreateAsync_Test()
        {
            var expectedType = typeof(UWP.Services.LocationService.LocationHelper);

            var actual = await new UWP.Services.LocationService.LocationHelper().CreateAsync();
            var actualType = actual.GetType();

            Assert.AreEqual(expectedType, actualType);
        }
    }
}
