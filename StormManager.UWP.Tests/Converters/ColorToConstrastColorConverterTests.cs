using System;
using System.Collections.Generic;
using Windows.UI;
using Castle.Components.DictionaryAdapter;
using StormManager.UWP.Annotations;
using StormManager.UWP.Converters;
using StormManager.UWP.Converters.ConversionHelpers;
using Xunit;

namespace StormManager.UWP.Tests.Converters
{
    public class ColorToConstrastColorConverterTests
    {
        private Dictionary<Tuple<Color, Color>, double?> ColorContrastPairs => new Dictionary<Tuple<Color, Color>, double?>
        {
            {new Tuple<Color, Color>(Colors.LightBlue, Colors.Blue), 0.5703125},
            {new Tuple<Color, Color>(Color.FromArgb(255, 255, 167, 242), Color.FromArgb(255, 255, 255, 255)), null},
            {new Tuple<Color, Color>(Color.FromArgb(255, 0, 216, 0), Color.FromArgb(255, 0, 217, 0)), 0.5}
        };

        [Fact]
        public void ColorToConstrastColorConverter_CanInstatiate()
        {
            var result = new ColorToConstrastColorConverter();
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(12, 167, 242)]
        [InlineData(212, 144, 22)]
        [InlineData(165, 23, 74)]
        public void ColorToConstrastColorConverter_CanConvert(byte r, byte g, byte b)
        {
            var expected = 0.30 * r + 0.59 * g + 0.11 * b > 127.5 ? Colors.Black : Colors.White;

            var converter = new ColorToConstrastColorConverter();
            var value = Color.FromArgb(255, r, g, b);
            var targetType = typeof(Color);
            var parameter = new object();
            var language = string.Empty;
            var result = converter.Convert(value, targetType, parameter, language);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ColorToConstrastColorConverter_ConvertBackReturnsProvidedValue()
        {
            var expectedBlack = Colors.Black;
            var expectedWhite = Colors.White;

            var converter = new ColorToConstrastColorConverter();
            var targetType = typeof(Color);
            var parameter = new object();
            var language = string.Empty;
            var resultBlack =converter.ConvertBack(expectedBlack, targetType, parameter, language);
            var resultWhite = converter.ConvertBack(expectedWhite, targetType, parameter, language);

            Assert.Equal(expectedBlack, resultBlack);
            Assert.Equal(expectedWhite, resultWhite);
        }

        [Theory]
        [InlineData(12, 167, 242)]
        [InlineData(212, 144, 22)]
        [InlineData(165, 23, 74)]
        public void ColorToConstrastColorConverter_ReturnsAccurateContrastValue(byte r, byte g, byte b)
        {
            var expected = 0.30 * r + 0.59 * g + 0.11 * b;

            var result = ColorToConstrastColorConverter.ContrastValue(Color.FromArgb(255, r, g, b));

            Assert.Equal(expected, result);
        }

        [Fact]
        public void olorToConstrastColorConverter_ContrastColorChangeFactorCorrect()
        {
            foreach (var pair in ColorContrastPairs)
            {
                var expected = pair.Value;

                IContrastFactorApproximationHelper helper = new ContrastFactorApproximationHelper();
                var result = ColorToConstrastColorConverter.ContrastColorChangeFactor(pair.Key.Item1, pair.Key.Item2, helper);

                Assert.Equal(expected, result);
            }
        }

        [Theory]
        [InlineData(0, 255, true)]
        [InlineData(127.4, 127.6, true)]
        [InlineData(72, 125, false)]
        [InlineData(172, 225, false)]
        [InlineData(127.5, 127.5, false)]
        public void MidPointExists_IsAccurate(double input1, double input2, bool expected)
        {
            var result = ColorToConstrastColorConverter.MidPointExists(input1, input2);
            Assert.Equal(expected, result);
        }
    }
}
