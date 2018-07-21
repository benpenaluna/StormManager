namespace StormManager.UWP.ViewModels.PlanningPageViewModel
{
    public class PlanningPageViewModel : PageViewModel, IPlanningPageViewModel
    {
        public SmeacsPartViewModel SmeacsPartViewModel { get; } = new SmeacsPartViewModel();

        public WeatherPartViewModel WeatherPartViewModel { get; } = new WeatherPartViewModel();

        public ReconnaissancePartViewModel ReconnaissancePartViewModel { get; } = new ReconnaissancePartViewModel();
    }
}
