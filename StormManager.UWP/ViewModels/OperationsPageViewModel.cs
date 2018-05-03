using Template10.Mvvm;

namespace StormManager.UWP.ViewModels
{
    public class OperationsPageViewModel : ViewModelBase
    {
        public MapPartViewModel MapPartViewModel { get; } = new MapPartViewModel();

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
