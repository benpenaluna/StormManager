using System;
using Windows.UI;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class ColorExtensions
    {
        public static Color FindMidColor(Color color1, Color color2)
        {
            var a = Convert.ToByte(Math.Min(color1.A, color2.A) + Math.Abs(color1.A - color2.A) / 2);
            var r = Convert.ToByte(Math.Min(color1.R, color2.R) + Math.Abs(color1.R - color2.R) / 2);
            var g = Convert.ToByte(Math.Min(color1.G, color2.G) + Math.Abs(color1.G - color2.G) / 2);
            var b = Convert.ToByte(Math.Min(color1.B, color2.B) + Math.Abs(color1.B - color2.B) / 2);
            return Color.FromArgb(a, r, g, b);
        }
    }
}
