using StormManager.UWP.Common.ExtensionMethods;
using Xunit;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    public class MapKeyExtensionsTests
    {
        [Fact]
        public void MapKeyLength_Returns108()
        {
            const int expected = 108;
            var actual = KeyExtensions.MapKeyLength;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MaxAsciiValue_Returns126()
        {
            const int expected = 126;
            var actual = KeyExtensions.MaxAsciiValue;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinAsciiValue_Returns33()
        {
            const int expected = 33;
            var actual = KeyExtensions.MinAsciiValue;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(882947765)]
        [InlineData(2147483646)]
        [InlineData(42)]
        public void IsValidMapKey_InvalidLength(int seed)
        {
            var undersizeKeyLength = KeyGenerator.GenerateValidKey(KeyExtensions.MapKeyLength - 1, seed);
            var oversizeKeyLength = KeyGenerator.GenerateValidKey(KeyExtensions.MapKeyLength + 1, seed);

            Assert.False(undersizeKeyLength.IsValidMapKey());
            Assert.False(oversizeKeyLength.IsValidMapKey());
        }

        [Fact]
        public void IsValidMapKey_InvalidCharacters()
        {
            var invalidKey = InvalidKey(KeyExtensions.MapKeyLength);

            Assert.False(invalidKey.IsValidMapKey());
        }

        [Theory]
        [InlineData(882947765)]
        [InlineData(2147483646)]
        [InlineData(42)]
        public void IsValidMapKey_ValidKey(int seed)
        {
            var validKey = KeyGenerator.GenerateValidKey(KeyExtensions.MapKeyLength, seed);

            Assert.True(validKey.IsValidMapKey());
        }

        private static string InvalidKey(int size)
        {
            const string whiteSpace = "";
            return whiteSpace.PadRight(size);
        }
    }
}
