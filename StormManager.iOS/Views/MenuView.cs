using CoreGraphics;
using MvvmCross.iOS.Views;
using StormManager.Core.ViewModels;
using UIKit;

namespace StormManager.iOS.Views
{
    [MvxPanelPresentation(MvxPanelEnum.Left, MvxPanelHintType.ActivePanel, false)]
    public partial class MenuView : MvxViewController<MenuViewModel>
    {
        private CGColor _borderColor = new CGColor(45, 177, 128);
        private UIColor _textColor = UIColor.White;
        private readonly UIColor _backgroundColor = UIColor.FromRGB(34, 33, 33);

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            View.BackgroundColor = _backgroundColor;
            // This is the default value of edgesForExtendedLayout
            EdgesForExtendedLayout = UIRectEdge.None;

            MenuTableView.BackgroundColor = UIColor.Clear;
            //Corner radius and color
            //ProfileImage.Layer.CornerRadius = (ProfileImage.Frame.Width / 2);
            //ProfileImage.Layer.BorderWidth = 1.5f;
            //ProfileImage.Layer.BorderColor = borderColor;
            //ProfileImage.Layer.MasksToBounds = true;

            //Label colors
            //BigLabel.TextColor = TextColor;
            //SmallLabel.TextColor = TextColor;

            MenuTableView.Source = new MenuTableViewSource(ViewModel.MenuItems);
            MenuTableView.SeparatorColor = UIColor.FromRGBA(187, 187, 187, 0.1f);

            MenuTableView.TableFooterView = new UIView(CGRect.Empty) { BackgroundColor = _backgroundColor };


            //MenuTableView.TableFooterView.Hidden = false;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}