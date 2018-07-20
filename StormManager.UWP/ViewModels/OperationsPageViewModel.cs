using Template10.Mvvm;

namespace StormManager.UWP.ViewModels
{
    public class OperationsPageViewModel : PageViewModel
    {
        public MapPartViewModel MapPartViewModel { get; } = new MapPartViewModel();

        public RfaPartViewModel RfaPartViewModel { get; } = new RfaPartViewModel();

        public TaskAssignmentPartViewModel TaskAssignmentPartViewModel { get; } = new TaskAssignmentPartViewModel();

        public DebriefPartViewModel DebriefPartViewModel { get; } = new DebriefPartViewModel();
    }
}
