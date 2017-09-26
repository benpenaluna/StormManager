using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace StormManager.UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OperationsPage : Page
    {
        public OperationsPage()
        {
            this.InitializeComponent();
        }

        //private void MyMap_Loaded(object sender, RoutedEventArgs e)
        //{
        //    //var centre = new Geopoint(new BasicGeoposition()
        //    //{
        //    //    // Melbourne GPO
        //    //    Latitude = -37.813840,
        //    //    Longitude = 144.963000
        //    //});
        //    //await MyMenuMapControl.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(centre, 3000));

        //    MyMenuMapControl.MapCenter = new Geopoint(new BasicGeoposition()
        //    {
        //        // Melbourne GPO
        //        Latitude = -37.813840,
        //        Longitude = 144.963000
        //    });

        //    MyMenuMapControl.MapZoomLevel = 14.0;
        //}
    }
}
