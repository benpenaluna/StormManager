using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class ColorAnimationHelper : IColorAnimationHelper
    {
        public Color FromColor { get; set; }
        public Color ToColor { get; set; }
        public TimeSpan Duration { get; set; }

        public void Initialise(Color fromColor, Color toColor, TimeSpan duration)
        {
            FromColor = fromColor;
            ToColor = toColor;
            Duration = duration;
        }
    }
}
