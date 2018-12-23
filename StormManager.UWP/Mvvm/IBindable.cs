using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StormManager.UWP.Mvvm
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Mvvm/IBindable.cs

    // this exists for the future implementation of the INPC property attribute
    public interface IBindable : INotifyPropertyChanged
    {
        void RaisePropertyChanged([CallerMemberName] string propertyName = null);
    }
}
