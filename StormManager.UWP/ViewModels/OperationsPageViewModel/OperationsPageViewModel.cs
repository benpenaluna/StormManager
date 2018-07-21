namespace StormManager.UWP.ViewModels.OperationsPageViewModel
{
    public class OperationsPageViewModel : PageViewModel, IOperationsPageViewModel
    {
        public MapPartViewModel MapPartViewModel { get; } = new MapPartViewModel();

        public RfaPartViewModel RfaPartViewModel { get; } = new RfaPartViewModel();

        public TaskAssignmentPartViewModel TaskAssignmentPartViewModel { get; } = new TaskAssignmentPartViewModel();

        public DebriefPartViewModel DebriefPartViewModel { get; } = new DebriefPartViewModel();
    }
}
