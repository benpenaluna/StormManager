using System.Windows.Input;

namespace StormManager.UWP.Mvvm
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Mvvm/IChangedCommand.cs

    /// <summary>
    /// Extension of <see cref="ICommand"/> to allow manually call of <see cref="ICommand.CanExecuteChanged"/>
    /// </summary>
    public interface IChangedCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }

}
