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
        private const int Seed = 882947765; // Arbitrary value to ensure that tests are repeatable

        [Fact]
        public void MapKeyLength_Returns108()
        {
            const int expected = 108;
            var actual = MapKeyExtensions.MapKeyLength();
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsValidMapKey_InvalidLength()
        {
            var undersizeKeyLength = ValidKey(MapKeyExtensions.MapKeyLength() - 1, Seed);
            var oversizeKeyLength = ValidKey(MapKeyExtensions.MapKeyLength() + 1, Seed);

            Assert.Equal(false, undersizeKeyLength.IsValidMapKey());
            Assert.Equal(false, oversizeKeyLength.IsValidMapKey());
        }

        [Fact]
        public void IsValidMapKey_InvalidCharacters()
        {
            var invalidKey = InvalidKey(MapKeyExtensions.MapKeyLength());

            Assert.Equal(false, invalidKey.IsValidMapKey());
        }

        [Fact]
        public void IsValidMapKey_ValidKey()
        {
            var validKey = ValidKey(MapKeyExtensions.MapKeyLength(), Seed);

            Assert.Equal(true, validKey.IsValidMapKey());
        }

        private static string ValidKey(int size, int seed)
        {
            const int minValue = 33;
            const int maxValue = 126;
            const int multiplier = maxValue - minValue + 1;

            var random = new Random(seed);
            var key = new StringBuilder();

            for (var i = 0; i < size; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(multiplier * random.NextDouble() + minValue)));
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
