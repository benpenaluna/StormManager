using Windows.UI.Xaml.Navigation;

namespace StormManager.UWP.Views
{
    public sealed partial class SettingsPage
    {
        readonly Template10.Services.SerializationService.ISerializationService _serializationService;

        public SettingsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Required;
            _serializationService = Template10.Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_serializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }
    }
}
