using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace StormManager.UWP.Services.SettingsServices
{
    public interface IUiUpdater
    {
        void UpdateUseShellBackButton(bool value);

        void UpdateAppTheme(ApplicationTheme appTheme);

        void UpdateCacheMaxDuration(TimeSpan value);
    }
}
