using System;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public abstract class JobTypeColorAnimation : IColorAnimationHelper 
    {
        public Color FromColor { get; protected set; }
        public Color ToColor { get; protected set; }
        public TimeSpan Duration => new TimeSpan(0, 0, 20);  // TODO: Wire this up to the app settings
    }
}
