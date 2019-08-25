using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StormManager.UWP.Models;

namespace StormManager.UWP.Views
{
    public sealed partial class SettingsPage
    {
        readonly Services.SerializationService.ISerializationService _serializationService;

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

        //private void JobTypesGridView_OnItemClick(object sender, ItemClickEventArgs e)
        //{
        //    if (e.ClickedItem is JobType selection && selection.Id != 0)
        //        return;

        //    // TODO: Add logic to add a new Job Type
        //    throw new System.NotImplementedException();
        //}
    }
}
