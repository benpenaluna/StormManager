﻿using System;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public abstract class ColorAnimationHelper : IColorAnimationHelper
    {
        public AnimateColor AnimateColor { get; set; }
        public Color FromColor { get; protected set; }
        public Color ToColor { get; protected set; }
        public virtual TimeSpan Duration => new TimeSpan(0, 0, 20);  // TODO: Wire this up to the app settings
    }
}
