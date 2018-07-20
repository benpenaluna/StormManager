namespace StormManager.UWP.ViewModels
{
    public class LogisticsPageViewModel : PageViewModel
    {
        public VehiclesPartViewModel VehiclesPartViewModel { get; } = new VehiclesPartViewModel();

        public PeoplePartViewModel PeoplePartViewModel { get; } = new PeoplePartViewModel();

        public AssignmentsPartViewModel AssignmentsPartViewModel { get; } = new AssignmentsPartViewModel();

        public DutyTimesPartViewModel DutyTimesPartViewModel { get; } = new DutyTimesPartViewModel();
    }
}
