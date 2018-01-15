using System;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public interface IMapIconControlHelper
    {
        DateTime NotificationTimeUtc { get; set; }

        IColorAnimationHelper ColorAnimationSettings { get; set; }
    }
}
