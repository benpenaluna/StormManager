using StormManager.UWP.Converters;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class TreeDownColorAnimation : JobTypeColorAnimation 
    {
        public TreeDownColorAnimation()
        {
            var green = Colors.Green;

            FromColor = ColorToConstrastColorConverter.LightenColor(green, 0.5);
            ToColor = green;
        }
    }
}
