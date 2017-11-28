using System.Linq;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class MapKeyExtensions
    {
        public static int MapKeyLength()
        {
            return 108;
        }

        public static bool IsValidMapKey(this string key)
        {
            return key.Length == MapKeyLength() && key.ToCharArray().Select(c => (int) c).All(i => i >= 33 && i <= 126);
        }
    }
}
