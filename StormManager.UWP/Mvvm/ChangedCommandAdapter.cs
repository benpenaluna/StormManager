﻿using System;
using System.Windows.Input;

namespace StormManager.UWP.Mvvm
{
    // Source: https://github.com/Windows-XAML/Template10/blob/version_1.1.12/Template10%20(Library)/Mvvm/ChangedCommandAdapter.cs

    /// <summary>
    /// Use this to adapt any <see cref="ICommand"/> to <see cref="IChangedCommand"/> with posibility to manually initiate 
    /// <see cref="CanExecuteChanged"/>
    /// </summary>
    public class ChangedCommandAdapter : IChangedCommand
    {
        private readonly ICommand command;
        private readonly Action raiseCanExecuteChangedAction;

        public ChangedCommandAdapter(ICommand command, Action raiseCanExecuteChangedAction)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));
            this.command = command;
            this.raiseCanExecuteChangedAction = raiseCanExecuteChangedAction;
        }

        public bool CanExecute(object parameter)
        {
            return command.CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            command.Execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { command.CanExecuteChanged += value; }
            remove { command.CanExecuteChanged -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            raiseCanExecuteChangedAction?.Invoke();
        }
    }
}
