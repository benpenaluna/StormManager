using System;
using Windows.UI.Xaml.Data;

namespace StormManager.UWP.Converters
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Converters/DateTimeOffsetConverter.cs
    // DOCS: https://github.com/Windows-XAML/Template10/wiki/Docs-%7C-Converters
    public class DateTimeOffsetConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try { return new DateTimeOffset((DateTime)value); }
            catch (Exception) { return default(DateTimeOffset); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try { return ((DateTimeOffset)value).DateTime; }
            catch (Exception) { return default(DateTime); }
        }
    }
}
