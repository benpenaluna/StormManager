using Template10.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class SettingsPageViewModel : ViewModelBase, ISettingsPageViewModel
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }
}

