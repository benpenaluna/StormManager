namespace StormManager.UWP.ViewModels.LogisticsPageViewModel
{
    public class LogisticsPageViewModel : PageViewModel, ILogisticsPageViewModel
    {
        public VehiclesPartViewModel VehiclesPartViewModel { get; } = new VehiclesPartViewModel();

        public PeoplePartViewModel PeoplePartViewModel { get; } = new PeoplePartViewModel();

        public AssignmentsPartViewModel AssignmentsPartViewModel { get; } = new AssignmentsPartViewModel();

        public DutyTimesPartViewModel DutyTimesPartViewModel { get; } = new DutyTimesPartViewModel();
    }
}
