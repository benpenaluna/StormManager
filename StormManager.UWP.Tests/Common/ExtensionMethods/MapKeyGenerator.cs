using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StormManager.UWP.Common.ExtensionMethods;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    public static class MapKeyGenerator
    {
        public static string GenerateValidKey(int size, int seed)
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
    }
}
