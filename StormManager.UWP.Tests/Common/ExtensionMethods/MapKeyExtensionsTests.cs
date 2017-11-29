using StormManager.UWP.Common.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    public class MapKeyExtensionsTests
    {
         [Fact]
        public void MapKeyLength_Returns108()
        {
            const int expected = 108;
            var actual = MapKeyExtensions.MapKeyLength;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxAsciiValue_Returns126()
        {
            const int expected = 126;
            var actual = MapKeyExtensions.MaxAsciiValue ;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinAsciiValue_Returns33()
        {
            const int expected = 33;
            var actual = MapKeyExtensions.MinAsciiValue;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(882947765)]
        [InlineData(2147483646)]
        [InlineData(42)]
        public void IsValidMapKey_InvalidLength(int seed)
        {
            var undersizeKeyLength = ValidKey(MapKeyExtensions.MapKeyLength - 1, seed);
            var oversizeKeyLength = ValidKey(MapKeyExtensions.MapKeyLength + 1, seed);

            Assert.Equal(false, undersizeKeyLength.IsValidMapKey());
            Assert.Equal(false, oversizeKeyLength.IsValidMapKey());
        }

        [Fact]
        public void IsValidMapKey_InvalidCharacters()
        {
            var invalidKey = InvalidKey(MapKeyExtensions.MapKeyLength);

            Assert.Equal(false, invalidKey.IsValidMapKey());
        }

        [Theory]
        [InlineData(882947765)]
        [InlineData(2147483646)]
        [InlineData(42)]
        public void IsValidMapKey_ValidKey(int seed)
        {
            var validKey = ValidKey(MapKeyExtensions.MapKeyLength, seed);

            Assert.Equal(true, validKey.IsValidMapKey());
        }

        private static string ValidKey(int size, int seed)
        {
            var multiplier = MapKeyExtensions.MaxAsciiValue - MapKeyExtensions.MinAsciiValue + 1;

            var random = new Random(seed);
            var key = new StringBuilder();

            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(multiplier * random.NextDouble() + MapKeyExtensions.MinAsciiValue)));
                key.Append(ch);
            }

            return key.ToString();
        }

        private static string InvalidKey(int size)
        {
            const string whiteSpace = "";
            return whiteSpace.PadRight(size);
        }
    }
}
