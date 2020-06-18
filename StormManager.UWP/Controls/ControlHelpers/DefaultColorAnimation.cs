using System;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class DefaultColorAnimation : ColorAnimationHelper
    {
        public override TimeSpan Duration => new TimeSpan(0, 0, 10);

        public DefaultColorAnimation()
        {
            FromColor = Colors.DimGray;
            ToColor = Colors.Black;
        }
    }
}
