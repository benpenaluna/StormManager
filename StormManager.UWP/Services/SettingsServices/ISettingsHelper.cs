namespace StormManager.UWP.Services.SettingsServices
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/SettingsService/ISettingsHelper.cs

    public interface ISettingsHelper
    {
        ISettingsService Container(SettingsStrategies strategy);
        bool Exists(string key, SettingsStrategies strategy = SettingsStrategies.Local);
        T Read<T>(string key, T otherwise, SettingsStrategies strategy = SettingsStrategies.Local);
        void Remove(string key, SettingsStrategies strategy = SettingsStrategies.Local);
        void Write<T>(string key, T value, SettingsStrategies strategy = SettingsStrategies.Local);
    }
}
