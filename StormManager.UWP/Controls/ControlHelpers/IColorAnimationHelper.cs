using System;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public interface IColorAnimationHelper
    {
        AnimateColor AnimateColor { get; set; }
        Color FromColor { get; }
        Color ToColor { get; }
        TimeSpan Duration { get; }
    }
}
