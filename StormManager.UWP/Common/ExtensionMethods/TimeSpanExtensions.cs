using System;
using System.Text;

namespace StormManager.UWP.Common.ExtensionMethods
{
    public static class TimeSpanExtensions
    {
        public static string SecondsOnlyFormat(this TimeSpan timeSinceNotification)
        {
            var totalSeconds = (int)Math.Floor(timeSinceNotification.TotalSeconds);
            return $"{totalSeconds} second{(timeSinceNotification.Seconds == 1 ? "" : "s")} ago";
        }

        public static string MinutesOnlyFormat(this TimeSpan timeSinceNotification)
        {
            var totalMinutes = (int)Math.Floor(timeSinceNotification.TotalMinutes);
            return $"{totalMinutes} minute{(totalMinutes == 1 ? "" : "s")} ago";
        }

        public static string HoursMinutesFormat(this TimeSpan timeSinceNotification)
        {
            var totalHours = (int)Math.Floor(timeSinceNotification.TotalHours);
            var totalMinutes = timeSinceNotification.Minutes;

            var timeToDisplay = new StringBuilder();

            timeToDisplay.Append($"{totalHours} hour{(totalHours == 1 ? "" : "s")}");

            if (totalMinutes != 0)
            {
                timeToDisplay.Append($" {totalMinutes} minute{(totalMinutes == 1 ? "" : "s")}");
            }

            return timeToDisplay.Append(" ago").ToString();
        }

        public static string DaysHoursFormat(this TimeSpan timeSinceNotification)
        {
            var totalDays = (int)Math.Floor(timeSinceNotification.TotalDays);
            var totalHours = timeSinceNotification.Hours;

            var timeToDisplay = new StringBuilder();

            timeToDisplay.Append($"{totalDays} day{(totalDays == 1 ? "" : "s")}");

            if (totalHours != 0)
            {
                timeToDisplay.Append($" {totalHours} hour{(totalHours == 1 ? "" : "s")}");
            }

            return timeToDisplay.Append(" ago").ToString();
        }
    }
}
