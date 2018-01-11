using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class BuildingDamageColorAnimation : JobTypeColorAnimation
    {
        public BuildingDamageColorAnimation()
        {
            FromColor = Colors.LightPink;
            ToColor = Colors.Red;
        }
    }
}
