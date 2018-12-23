using System.ComponentModel;

namespace StormManager.UWP.Common
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Common/ItemPropertyChangedEventArgs.cs

    public class ItemPropertyChangedEventArgs
    {
        public ItemPropertyChangedEventArgs(object item, int changedIndex, PropertyChangedEventArgs e)
        {
            ChangedItem = item;
            ChangedItemIndex = changedIndex;
            PropertyChangedArgs = e;
        }
        public object ChangedItem { get; set; }

        public int ChangedItemIndex { get; set; }

        public PropertyChangedEventArgs PropertyChangedArgs { get; set; }
    }
}
