namespace StormManager.UWP.ViewModels
{
    public class PlanningPageViewModel : PageViewModel
    {
        public SmeacsPartViewModel SmeacsPartViewModel { get; } = new SmeacsPartViewModel();

        public WeatherPartViewModel WeatherPartViewModel { get; } = new WeatherPartViewModel();

        public ReconnaissancePartViewModel ReconnaissancePartViewModel { get; } = new ReconnaissancePartViewModel();
    }
}
