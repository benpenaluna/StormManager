using StormManager.UWP.Common.ExtensionMethods;
using System;
using Xunit;

namespace StormManager.UWP.Tests.Common.ExtensionMethods
{
    public class TimeSpanExtensionTests
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 876)]
        public void SecondsOnlyFormat_CorrectlyFormats1second(int seconds, int milliseconds)
        {
            const string expected = "1 second ago";

            const int days = 0;
            const int hours = 0;
            const int minutes = 0;
            var timeSpan = new TimeSpan(days, hours, minutes, seconds, milliseconds);
            var result = timeSpan.SecondsOnlyFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(4, 0)]
        [InlineData(32, 76)]
        [InlineData(64, 567)]
        [InlineData(3604, 62)]
        [InlineData(86404, 876)]
        public void SecondsOnlyFormat_CorrectlyFormatsMoreThan1second(int seconds, int milliseconds)
        {
            var expected = $"{seconds} seconds ago";

            const int days = 0;
            const int hours = 0;
            const int minutes = 0;
            var timeSpan = new TimeSpan(days, hours, minutes, seconds, milliseconds);
            var result = timeSpan.SecondsOnlyFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 24)]
        public void MinutesOnlyFormat_CorrectlyFormats1minute(int minutes, int seconds)
        {
            const string expected = "1 minute ago";

            const int hours = 0;
            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.MinutesOnlyFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 24)]
        [InlineData(8, 0)]
        [InlineData(32, 0)]
        [InlineData(64, 0)]
        [InlineData(1444, 0)]
        public void MinutesOnlyFormat_CorrectlyFormatsMoreThan1minute(int minutes, int seconds)
        {
            var expected = $"{minutes} minutes ago";

            const int hours = 0;
            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.MinutesOnlyFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(1, 0, 24)]
        public void HoursMinutesFormat_CorrectlyFormats1HourZeroMinutes(int hours, int minutes, int seconds)
        {
            var expected = $"{hours} hour ago";

            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.HoursMinutesFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(2, 0, 24)]
        [InlineData(28, 0, 51)]
        public void HoursMinutesFormat_CorrectlyFormatsManyHoursZeroMinutes(int hours, int minutes, int seconds)
        {
            var expected = $"{hours} hours ago";

            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.HoursMinutesFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1, 1, 24)]
        public void HoursMinutesFormat_CorrectlyFormats1Hour1Minute(int hours, int minutes, int seconds)
        {
            var expected = $"{hours} hour {minutes} minute ago";

            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.HoursMinutesFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 0)]
        [InlineData(1, 26, 24)]
        public void HoursMinutesFormat_CorrectlyFormats1HourManyMinutes(int hours, int minutes, int seconds)
        {
            var expected = $"{hours} hour {minutes} minutes ago";

            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.HoursMinutesFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(2, 1, 24)]
        [InlineData(28, 1, 24)]
        public void HoursMinutesFormat_CorrectlyFormatsManyHours1Minute(int hours, int minutes, int seconds)
        {
            var expected = $"{hours} hours {minutes} minute ago";

            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.HoursMinutesFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 12, 0)]
        [InlineData(2, 16, 24)]
        [InlineData(28, 52, 24)]
        public void HoursMinutesFormat_CorrectlyFormatsManyHoursManyMinutes(int hours, int minutes, int seconds)
        {
            var expected = $"{hours} hours {minutes} minutes ago";

            var timeSpan = new TimeSpan(hours, minutes, seconds);
            var result = timeSpan.HoursMinutesFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 0, 0, 0)]
        [InlineData(1, 0, 24, 6)]
        public void DaysHoursFormat_CorrectlyFormats1DayZeroHours(int days, int hours, int minutes, int seconds)
        {
            var expected = $"{days} day ago";

            var timeSpan = new TimeSpan(days, hours, minutes, seconds);
            var result = timeSpan.DaysHoursFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(2, 0, 24, 17)]
        [InlineData(28, 0, 51, 22)]
        public void DaysHoursFormat_CorrectlyFormatsManyDaysZeroHours(int days, int hours, int minutes, int seconds)
        {
            var expected = $"{days} days ago";

            var timeSpan = new TimeSpan(days, hours, minutes, seconds);
            var result = timeSpan.DaysHoursFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 1, 0, 0)]
        [InlineData(1, 1, 24, 42)]
        public void DaysHoursFormat_CorrectlyFormats1Day1Hour(int days, int hours, int minutes, int seconds)
        {
            var expected = $"{days} day {hours} hour ago";

            var timeSpan = new TimeSpan(days, hours, minutes, seconds);
            var result = timeSpan.DaysHoursFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 0, 17)]
        [InlineData(1, 23, 24, 37)]
        public void DaysHoursFormat_CorrectlyFormats1DayManyHours(int days, int hours, int minutes, int seconds)
        {
            var expected = $"{days} day {hours} hours ago";

            var timeSpan = new TimeSpan(days, hours, minutes, seconds);
            var result = timeSpan.DaysHoursFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 1, 0, 6)]
        [InlineData(2, 1, 24, 22)]
        [InlineData(28, 1, 24, 8)]
        public void DaysHoursFormat_CorrectlyFormatsManyDays1Hour(int days, int hours, int minutes, int seconds)
        {
            var expected = $"{days} days {hours} hour ago";

            var timeSpan = new TimeSpan(days, hours, minutes, seconds);
            var result = timeSpan.DaysHoursFormat();

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 12, 0, 9)]
        [InlineData(2, 16, 24, 27)]
        [InlineData(28, 6, 24, 41)]
        public void DaysHoursFormat_CorrectlyFormatsManyDaysManyHours(int days, int hours, int minutes, int seconds)
        {
            var expected = $"{days} days {hours} hours ago";

            var timeSpan = new TimeSpan(days, hours, minutes, seconds);
            var result = timeSpan.DaysHoursFormat();

            Assert.Equal(expected, result);
        }
    }
}
