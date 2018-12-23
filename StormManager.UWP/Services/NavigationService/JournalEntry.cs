using System;

namespace StormManager.UWP.Services.NavigationService
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Services/NavigationService/JournalEntry.cs

    public class JournalEntry
    {
        public Type SourcePageType { get; internal set; }
        public object Parameter { get; internal set; }

        public override bool Equals(object obj)
        {
            var je = obj as JournalEntry;

            if (je == null)
            {
                return false;
            }

            bool ret =
                SourcePageType.Equals(je.SourcePageType) &&
                ((Parameter == null && je.Parameter == null) ||
                 (Parameter.Equals(je.Parameter)));

            return ret;
        }

        public override int GetHashCode()
        {
            int hash = 17;

            if (Parameter != null)
            {
                hash = hash * 23 + Parameter.GetHashCode();
            }
            else
            {
                hash = hash * 23;
            }

            hash = hash * 23 + SourcePageType.GetHashCode();

            return hash;
        }
    }
}
