using System.Linq;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class KeyExtensions
    {
        public static int MapKeyLength => 108;

        public static int MaxAsciiValue => 126;

        public static int MinAsciiValue => 33;

        public static bool IsValidMapKey(this string key)
        {
            return key.Length == MapKeyLength && key.ToCharArray().Select(c => (int)c).All(i => i >= MinAsciiValue && i <= MaxAsciiValue);
        }
    }
}
