using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public interface IMapIconControlHelper
    {
        DateTime NotificationTimeUtc { get; set; }

        IColorAnimationHelper ColorAnimationSettings { get; set; }
    }
}
