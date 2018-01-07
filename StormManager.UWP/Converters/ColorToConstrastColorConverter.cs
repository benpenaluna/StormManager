using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace StormManager.UWP.Converters
{
    public class ColorToConstrastColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var color = (Color) value;
            return ConvertToConstractColor(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }

        public static Color ConvertToConstractColor(Color color)
        {
            return ContrastValue(color) > 128 ? Colors.Black : Colors.White;
        }

        public static double ContrastValue(Color color)
        {
            return 0.30 * color.R + 0.59 * color.G + 0.11 * color.B;
        }
    }
}
