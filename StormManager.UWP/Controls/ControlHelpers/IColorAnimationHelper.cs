using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public interface IColorAnimationHelper
    {
        Color FromColor { get; set; }
        Color ToColor { get; set; }
        TimeSpan Duration { get; set; }

        void Initialise(Color fromColor, Color toColor, TimeSpan duration);
    }
}
