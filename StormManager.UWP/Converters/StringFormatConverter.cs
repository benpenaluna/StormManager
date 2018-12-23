using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace StormManager.UWP.Converters
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Converters/StringFormatConverter.cs

    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var format = (parameter as string) ?? Format;
            if (format == null)
                return value;

            if (string.IsNullOrWhiteSpace(language))
            {
                return string.Format(format, value);
            }

            try
            {
                var culture = new CultureInfo(language);
                return string.Format(culture, format, value);
            }
            catch
            {
                return string.Format(format, value);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        public string Format { get; set; }
    }
}
