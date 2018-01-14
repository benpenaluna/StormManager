﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public interface IColorAnimationHelper
    {
        MapIconControl.AnimateColor AnimateColor { get; set; }
        Color FromColor { get; }
        Color ToColor { get; }
        TimeSpan Duration { get; }
    }
}
