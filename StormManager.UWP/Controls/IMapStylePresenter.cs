using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media;

namespace StormManager.UWP.Controls
{

    public interface IMapStylePresenter
    {
        ImageSource MapImageSource { get; set; }
        MapStyle MapStyle { get; set; }
        Stretch Stretch { get; set; }
        string Text { get; }
    }
}
