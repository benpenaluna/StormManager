using System;
using System.Collections.Generic;
using Template10.Services.SettingsService;

namespace StormManager.UWP.Tests.Services.SettingsService
{
    internal class MockSettingsHelper : ISettingsHelper
    {
        private readonly Dictionary<string, string> _recordedSettings;

        public static ISettingsHelper Create()
        {
            return new MockSettingsHelper();
        }

        private MockSettingsHelper()
        {
            _recordedSettings = new Dictionary<string, string>();
        }

        public ISettingsService Container(SettingsStrategies strategy)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string key, SettingsStrategies strategy = SettingsStrategies.Local)
        {
            return _recordedSettings.ContainsKey(key);
        }

        public T Read<T>(string key, T otherwise, SettingsStrategies strategy = SettingsStrategies.Local)
        {
            _recordedSettings.TryGetValue(key, out var recordedValue);
            return ConvertValueToT(otherwise, recordedValue);
        }

        private static T ConvertValueToT<T>(T otherwise, string recordedValue)
        {
            T convertedValue;

            if (typeof(T) == typeof(TimeSpan))
            {
                TimeSpan.TryParse(recordedValue, out var timeSpan);
                convertedValue = (T) Convert.ChangeType(timeSpan, typeof(T));
            }
            else
            {
                convertedValue = recordedValue == null ? otherwise : (T)Convert.ChangeType(recordedValue, typeof(T));
            }

            return convertedValue;
        }

        public void Remove(string key, SettingsStrategies strategy = SettingsStrategies.Local)
        {
            _recordedSettings.Remove(key);
        }

        public void Write<T>(string key, T value, SettingsStrategies strategy = SettingsStrategies.Local)
        {
            _recordedSettings.Add(key, value.ToString());
        }
    }
}
