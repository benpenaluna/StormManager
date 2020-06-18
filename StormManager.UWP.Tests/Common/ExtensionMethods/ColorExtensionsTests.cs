using Windows.UI;
using Xunit;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    public class ColorExtensionsTests
    {
        private readonly Color[] _color1 =
        {
            Color.FromArgb(255, 255, 0, 0),
            Color.FromArgb(255, 173, 86, 245),
            Color.FromArgb(255, 8, 142, 225)
        };

        private readonly Color[] _color2 =
        {
            Color.FromArgb(255, 0, 0, 255),
            Color.FromArgb(255, 22, 178, 233),
            Color.FromArgb(255, 196, 128, 167)
        };

        private readonly Color[] _expected =
        {
            Color.FromArgb(255, 127, 0, 127),
            Color.FromArgb(255, 97, 132, 239),
            Color.FromArgb(255, 102, 135, 196)
        };


        [Fact]
        public void FindMidColor_IsAccurate()
        {
            for (var i = 0; i <= 2; i++)
            {
                var result = UWP.Common.ExtensionMethods.ColorExtensions.FindMidColor(_color1[i], _color2[i]);
                Assert.Equal(_expected[i], result);
            }
        }
    }
}
