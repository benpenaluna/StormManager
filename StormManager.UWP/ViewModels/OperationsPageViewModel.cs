using Template10.Mvvm;

namespace StormManager.UWP.ViewModels
{
    public class OperationsPageViewModel : ViewModelBase
    {
        public MapPartViewModel MapPartViewModel { get; } = new MapPartViewModel();
    }
}
