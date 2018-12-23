using System.ComponentModel;

namespace StormManager.UWP.Common
{
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
