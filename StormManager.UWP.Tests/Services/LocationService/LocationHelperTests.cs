using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StormManager.UWP.Tests.Services.LocationService
{
    public class LocationHelperTests
    {
        [Fact]
        public async Task LocationHelperInstatiates()
        {
            var actual = await new UWP.Services.LocationService.LocationHelper().CreateAsync();

            Assert.NotNull(actual);
        }
    }
}
