using System;

namespace StormManager.UWP.Common
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Common/ChangedEventArgs.cs

    public class ChangedEventArgs<TValue> : EventArgs
    {
        private readonly TValue oldValue;
        private readonly TValue newValue;

        public ChangedEventArgs(TValue oldValue, TValue newValue)
        {
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public TValue OldValue => oldValue;
        public TValue NewValue => newValue;
    }
}
