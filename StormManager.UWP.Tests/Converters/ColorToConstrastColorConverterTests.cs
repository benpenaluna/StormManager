using Xunit;

namespace StormManager.UWP.Tests.Converters
{
    public class ColorToConstrastColorConverterTests
    {
        [Theory]
        [InlineData(0, 255, true)]
        [InlineData(127.4, 127.6, true)]
        [InlineData(72, 125, false)]
        [InlineData(172, 225, false)]
        [InlineData(127.5, 127.5, false)]
        public void MidPointExists_IsAccurate(double input1, double input2, bool expected)
        {
            var result = UWP.Converters.ColorToConstrastColorConverter.MidPointExists(input1, input2);
            Assert.Equal(expected, result);
        }
    }
}
