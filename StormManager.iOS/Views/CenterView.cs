using MvvmCross.iOS.Support.SidePanels;
using MvvmCross.iOS.Views;
using StormManager.Core.ViewModels;
using UIKit;

namespace StormManager.iOS.Views
{
    [MvxPanelPresentation(MvxPanelEnum.Center, MvxPanelHintType.ResetRoot, true)]

    public partial class CenterView : MvxViewController<ContentViewModel>
    {

        public CenterView() { }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            //View.BackgroundColor = UIColor.Black;
            View.BackgroundColor = UIColor.White;

            ViewModel.ShowMenu();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}