using Autofac;
using System;

namespace StormManager.UWP.Controls.ControlHelpers
{
    public class MapIconControlHelper : IMapIconControlHelper
    {
        private DateTime _notificationTimeUtc = DateTime.UtcNow;

        public IColorAnimationHelper ColorAnimationSettings { get; set; }

        public DateTime NotificationTimeUtc
        {
            get => _notificationTimeUtc;
            set
            {
                if (value > DateTime.UtcNow)
                {
                    throw new ArgumentException(
                        string.Format("Notification time {0} is greater than current time {1}", value.ToLocalTime(), DateTime.Now));
                }

                _notificationTimeUtc = value;
            }
        }

        public MapIconControlHelper(IColorAnimationHelper helper = null)
        {
            ColorAnimationSettings = helper ?? App.Container.Resolve<IColorAnimationHelper>();
        }

        public static IMapIconControlHelper Create(IColorAnimationHelper helper = null)
        {
            return new MapIconControlHelper(helper);
        }
    }
}
