using Windows.Devices.Geolocation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StormManager.UWP.Common.ExtensionMethods;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    [TestClass]
    public class LocationExtensionsTests
    {
        [Theory]
        [InlineData(-37.0, 144.0)]
        [InlineData(37.0, -144.0)]
        public void ToGeopoint_Test(double latitude, double longitude)
        {
            var position = new BasicGeoposition() {Latitude = latitude, Longitude = longitude};
            var expectedGeopoint = new Geopoint(position);
            
            var actual = position.ToGeopoint();

            Assert.AreEqual(expectedGeopoint.Position.Latitude, actual.Position.Latitude);
            Assert.AreEqual(expectedGeopoint.Position.Longitude, actual.Position.Longitude);
        }
    }
}
