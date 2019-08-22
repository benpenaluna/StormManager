using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using StormManager.UWP.Models;

namespace StormManager.UWP.Behaviors
{
    public class JobTypeTemplateSelector : DataTemplateSelector
    {
        public DataTemplate OriginalTemplate { get; set; }
        public DataTemplate AddTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            return item is JobType jobType && jobType.Id == 0 ? AddTemplate : OriginalTemplate;
        }
    }
}
