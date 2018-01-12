using StormManager.UWP.Converters;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class TreeDownColorAnimation : JobTypeColorAnimation 
    {
        public TreeDownColorAnimation()
        {
            FromColor = Colors.LightGreen;
            ToColor = Colors.Green;
        }
    }
}
