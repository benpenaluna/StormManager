using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class BuildingDamageColorAnimation : ColorAnimationHelper
    {
        public BuildingDamageColorAnimation()
        {
            FromColor = Colors.LightPink;
            ToColor = Colors.Red;
        }
    }
}
