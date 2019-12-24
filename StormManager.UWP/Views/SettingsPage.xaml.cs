using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace StormManager.UWP.Views
{
    public sealed partial class SettingsPage
    {
        readonly Services.SerializationService.ISerializationService _serializationService;

        private const double JobTypeContentFrameWidth = 450.0D;

        public SettingsPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
            _serializationService = Services.SerializationService.SerializationService.Json;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var index = int.Parse(_serializationService.Deserialize(e.Parameter?.ToString()).ToString());
            MyPivot.SelectedIndex = index;
        }

        private void JobTypesSplitView_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            JobTypesSplitView.OpenPaneLength = JobTypesSplitView.ActualWidth > JobTypeContentFrameWidth ?
                                               JobTypesSplitView.ActualWidth - JobTypeContentFrameWidth :
                                               0.0D;
        }
    }
}
