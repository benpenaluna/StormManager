using System.Threading.Tasks;
using Windows.UI.Xaml;
using Autofac;
using StormManager.UWP.Services.ResourceLoaderService;
using StormManager.UWP.Services.SettingsServices;
using StormManager.UWP.Mvvm;

namespace StormManager.UWP.ViewModels.SettingPageViewModel
{
    public class SettingsPartViewModel : ViewModelBase
    {
        //readonly Services.SettingsServices.AppSettingsService _appSettings;
        readonly IAppSettingsService _appSettings;

        public SettingsPartViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
            {
                // designtime
            }
            else
            {
                _appSettings = App.Container.Resolve<IAppSettingsService>();
            }
        }

        public bool ShowHamburgerButton
        {
            get => _appSettings.ShowHamburgerButton;
            set { _appSettings.ShowHamburgerButton = value; RaisePropertyChanged(); }
        }

        public bool IsFullScreen
        {
            get => _appSettings.IsFullScreen;
            set
            {
                _appSettings.IsFullScreen = value;
                RaisePropertyChanged();
                ShowHamburgerButton = !value;
            }
        }

        public bool UseShellBackButton
        {
            get => _appSettings.UseShellBackButton;
            set { _appSettings.UseShellBackButton = value; RaisePropertyChanged(); }
        }

        public bool UseLightThemeButton
        {
            get => _appSettings.AppTheme.Equals(ApplicationTheme.Light);
            set { _appSettings.AppTheme = value ? ApplicationTheme.Light : ApplicationTheme.Dark; RaisePropertyChanged(); }
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

