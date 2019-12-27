using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using StormManager.UWP.Models;

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

        public void AutoSuggestBoxSearch_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason != AutoSuggestionBoxTextChangeReason.UserInput || JobTypesListView.Items == null)
                return;

            sender.ItemsSource = DetermineEligibleSuggestions(sender.Text, JobTypesListView.Items);
        }

        private static ObservableCollection<string> DetermineEligibleSuggestions(string userSearchText, ItemCollection items)
        {
            var options = new ObservableCollection<string>();
            foreach (var item in items)
            {
                var jobType = GetJobType(item);
                if (jobType == null)
                    continue;

                if (jobType.Category.Contains(userSearchText) || jobType.SubCategory.Contains(userSearchText))
                    options.Add(jobType.ToString());
            }

            return options;
        }

        private static JobType GetJobType(object item)
        {
            return item.GetType() == typeof(JobType) ? item as JobType : null;
        }

        public void AutoSuggestBoxSearch_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
        }


        public void AutoSuggestBoxSearch_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {

            }
            //else
            //{
            //    // Use args.QueryText to determine what to do.
            //}
        }
    }
}
