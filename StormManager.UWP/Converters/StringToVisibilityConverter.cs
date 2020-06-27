using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace StormManager.UWP.Converters
{
    public class StringToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (!string.IsNullOrEmpty(value.ToString()) && value.ToString().ToUpper() == "NONE")
                return Visibility.Collapsed;
            
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
