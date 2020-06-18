using StormManager.UWP.Common.ExtensionMethods;
using Windows.UI;

namespace StormManager.UWP.Converters.ConversionHelpers
{
    public class ContrastFactorApproximationHelper : IContrastFactorApproximationHelper
    {
        //TODO: This class needs to be tested

        public double Factor { get; set; }

        public double Exponent { get; set; }

        public double Tolerance { get; set; }

        public Color HighColor { get; set; }

        public Color LowColor { get; set; }

        public Color MidColor { get; set; }

        public void Initialise(Color fromColor, Color toColor)
        {
            var fromColorContrastValue = ColorToConstrastColorConverter.ContrastValue(fromColor);
            var toColorContrastValue = ColorToConstrastColorConverter.ContrastValue(toColor);

            LowColor = fromColorContrastValue < toColorContrastValue ? fromColor : toColor;
            HighColor = fromColorContrastValue < toColorContrastValue ? toColor : fromColor;
            MidColor = ColorExtensions.FindMidColor(fromColor, toColor);

            Factor = 0.5;
            Exponent = 2.0;
            Tolerance = 0.25;
        }
    }
}
