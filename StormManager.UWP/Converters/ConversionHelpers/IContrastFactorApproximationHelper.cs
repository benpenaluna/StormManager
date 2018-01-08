using Windows.UI;

namespace StormManager.UWP.Converters.ConversionHelpers
{
    public interface IContrastFactorApproximationHelper
    {
        double Factor { get; set; }
        double Exponent { get; set; }
        double Tolerance { get; set; }

        Color HighColor { get; set; }
        Color LowColor { get; set; }
        Color MidColor { get; set; }

        void Initialise(Color fromColor, Color toColor);
    }
}
