using System.Threading.Tasks;
using Windows.UI.Xaml;
using Autofac;
using StormManager.UWP.Services.ResourceLoaderService;
using StormManager.UWP.Services.SettingsServices;
using Template10.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class SettingsPartViewModel : ViewModelBase
    {
        //readonly Services.SettingsServices.SettingsService _settings;
        readonly ISettingsService _settings;

        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _settings = App.Container.Resolve<ISettingsService>();
            }
        }

        public bool ShowHamburgerButton
        {
            get => _settings.ShowHamburgerButton;
            set { _settings.ShowHamburgerButton = value; RaisePropertyChanged(); }
        }

        public bool IsFullScreen
        {
            get => _settings.IsFullScreen;
            set
            {
                _settings.IsFullScreen = value;
                RaisePropertyChanged();
                ShowHamburgerButton = !value;
            }
        }

        public bool UseShellBackButton
        {
            get => _settings.UseShellBackButton;
            set { _settings.UseShellBackButton = value; RaisePropertyChanged(); }
        }

        public bool UseLightThemeButton
        {
            get => _settings.AppTheme.Equals(ApplicationTheme.Light);
            set { _settings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; RaisePropertyChanged(); }
        }

        private string _busyText = ResourceLoaderService.GetResourceValue("BusyText");

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
    }
}

