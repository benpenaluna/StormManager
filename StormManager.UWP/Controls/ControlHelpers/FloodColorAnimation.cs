using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class FloodColorAnimation : JobTypeColorAnimation 
    {
        public FloodColorAnimation()
        {
            FromColor = Colors.LightBlue;
            ToColor = Colors.Blue;
        }
    }
}
