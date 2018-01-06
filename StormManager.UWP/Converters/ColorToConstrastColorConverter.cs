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
            var greyShade = 0.30 * color.R + 0.59 * color.G + 0.11 * color.B;
            return greyShade > 128 ? Colors.Black : Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
