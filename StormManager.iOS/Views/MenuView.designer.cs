// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace StormManager.iOS.Views
{
    [Register ("MenuView")]
    partial class MenuView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView MenuTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MenuTableView != null) {
                MenuTableView.Dispose ();
                MenuTableView = null;
            }
        }
    }
}