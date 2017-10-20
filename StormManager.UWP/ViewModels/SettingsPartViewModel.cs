using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using StormManager.UWP.Services.ResourceLoaderService;

namespace StormManager.UWP.ViewModels
{
    public class SettingsPartViewModel : ViewModelBase
    {
        Services.SettingsServices.SettingsService _settings;

        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _settings = Services.SettingsServices.SettingsService.Instance;
            }
        }

        public bool ShowHamburgerButton
        {
            get => _settings.ShowHamburgerButton;
            set { _settings.ShowHamburgerButton = value; base.RaisePropertyChanged(); }
        }

        public bool IsFullScreen
        {
            get => _settings.IsFullScreen;
            set
            {
                _settings.IsFullScreen = value;
                base.RaisePropertyChanged();
                if (value)
                    ShowHamburgerButton = false;
                else
                    ShowHamburgerButton = true;
            }
        }

        public bool UseShellBackButton
        {
            get => _settings.UseShellBackButton;
            set { _settings.UseShellBackButton = value; base.RaisePropertyChanged(); }
        }

        public bool UseLightThemeButton
        {
            get => _settings.AppTheme.Equals(ApplicationTheme.Light);
            set { _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; base.RaisePropertyChanged(); }
        }

        private string _busyText = RetrieveResource("BusyText");

        public string BusyText
        {
            get => _busyText;
            set
            {
                Set(ref _busyText, value);
                _showBusyCommand.RaiseCanExecuteChanged();
            }
        }

        DelegateCommand _showBusyCommand;

        public DelegateCommand ShowBusyCommand
            => _showBusyCommand ?? (_showBusyCommand = new DelegateCommand(async () =>
            {
                Views.Busy.SetBusy(true, _busyText);
                await Task.Delay(5000);
                Views.Busy.SetBusy(false);
            }, () => !string.IsNullOrEmpty(BusyText)));

        private static string RetrieveResource(string name)
        {
            IResourceLoaderService resource = ResourceLoaderService.Instance;
            return resource.Value(name);
        }
    }
}

