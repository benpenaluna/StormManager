using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using StormManager.UWP.Controls.ControlHelpers;
using Xunit;

namespace StormManager.UWP.Tests.Controls.ControlHelpersTests
{
    public class ColorAnimationHelperTests
    {
        [Fact]
        public void ColorAnimationHelper_CanInstantiate()
        {
            var result = new ColorAnimationHelper();
            Assert.NotNull(result);
        }

        [Fact]
        public void ColorAnimationHelper_CanInitialise()
        {
            var expectedFromColor = Colors.Blue;
            var expectedTotoColor = Colors.Red;
            var expectedDuration = new TimeSpan(0,0,20);

            var result = new ColorAnimationHelper();
            result.Initialise(expectedFromColor, expectedTotoColor, expectedDuration);

            Assert.Equal(expectedFromColor, result.FromColor);
            Assert.Equal(expectedTotoColor, result.ToColor);
            Assert.Equal(expectedDuration, result.Duration);
        }
    }
}
