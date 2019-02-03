using StormManager.UWP.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class SettingsPageViewModel : ViewModelBase, ISettingsPageViewModel
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public JobTypesPartViewModel JobTypesPartViewModel { get; } = new JobTypesPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }
}

