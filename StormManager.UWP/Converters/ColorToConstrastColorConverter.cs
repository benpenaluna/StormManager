using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Autofac;
using StormManager.UWP.Common.ExtensionMethods;
using StormManager.UWP.Converters.ConversionHelpers;

namespace StormManager.UWP.Converters
{
    public class ColorToConstrastColorConverter : IValueConverter
    {
        private const double MidPoint = 127.5;

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
            return ContrastValue(color) > MidPoint ? Colors.Black : Colors.White;
        }

        public static double ContrastValue(Color color)
        {
            return 0.30 * color.R + 0.59 * color.G + 0.11 * color.B;
        }

        public static double? ContrastColorChangeFactor(Color fromColor, Color toColor)
        {
            if (!MidPointExists(ContrastValue(fromColor), ContrastValue(toColor)))
            {
                return null;
            }

            return ApproximateFactorUsingBiSection(fromColor, toColor);
        }

        public static bool MidPointExists(double fromColorContrastValue, double toColorContrastValue)
        {
            return (fromColorContrastValue <= MidPoint && toColorContrastValue > MidPoint) || 
                   (fromColorContrastValue > MidPoint && toColorContrastValue <= MidPoint);
        }

        private static double ApproximateFactorUsingBiSection(Color fromColor, Color toColor)
        {
            var helper = App.Container.Resolve<IContrastFactorApproximationHelper>();
            helper.Initialise(fromColor, toColor);

            var midColorContrastValue = ContrastValue(helper.MidColor);
            while (Math.Abs(MidPoint - midColorContrastValue) > helper.Tolerance)
            {
                var factorUpdateMagnitude = Math.Pow(0.5, helper.Exponent++);

                if (midColorContrastValue > MidPoint)
                {
                    helper.HighColor = helper.MidColor;
                    helper.Factor -= factorUpdateMagnitude;
                }
                else
                {
                    helper.LowColor = helper.MidColor;
                    helper.Factor += factorUpdateMagnitude;
                }

                helper.MidColor = ColorExtensions.FindMidColor(helper.LowColor, helper.HighColor);
                midColorContrastValue = ContrastValue(helper.MidColor);
            }

            return helper.Factor;
        }
    }
}
