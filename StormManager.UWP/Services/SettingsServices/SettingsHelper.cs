using StormManager.UWP.Services.AppPresentationService;

namespace StormManager.UWP.Services.SettingsServices
{
    public class SettingsHelper : ISettingsHelper
    {
        public IAppPresentationService Container(SettingsStrategies strategy)
        {
            return (strategy == SettingsStrategies.Local) ? Local : Roam;
        }
        
        public bool Exists(string key, SettingsStrategies strategy = SettingsStrategies.Local)
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                return true;
            }

            return Container(strategy).Exists(key);
        }
        
        public void Remove(string key, SettingsStrategies strategy = SettingsStrategies.Local)
            {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return;
            if (Container(strategy).Exists(key))
                Container(strategy).Remove(key);
            }
        
        public void Write<T>(string key, T value, SettingsStrategies strategy = SettingsStrategies.Local)
            {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return;
            Container(strategy).Write(key, value);
            }
        
        public T Read<T>(string key, T otherwise, SettingsStrategies strategy = SettingsStrategies.Local)
            {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                return otherwise;

                return Container(strategy).Read(key, otherwise);
            }
    }
}
