using StormManager.UWP.Common.ExtensionMethods;
using Windows.Devices.Geolocation;
using Xunit;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    public class LocationExtensionsTests
    {
        [Theory]
        [InlineData(-37.0, 144.0)]
        [InlineData(37.0, -144.0)]
        public void ToGeopoint_GivenBasicGeopsoition_ReturnsGeopoint(double latitude, double longitude)
        {
            var position = new BasicGeoposition() { Latitude = latitude, Longitude = longitude };
            var expectedGeopoint = new Geopoint(position);

            var actual = position.ToGeopoint();

            Assert.Equal(expectedGeopoint.Position.Latitude, actual.Position.Latitude);
            Assert.Equal(expectedGeopoint.Position.Longitude, actual.Position.Longitude);
        }
    }
}
