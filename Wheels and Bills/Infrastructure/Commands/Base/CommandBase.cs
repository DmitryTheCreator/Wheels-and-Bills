using System;
using System.Windows.Input;

namespace Wheels_and_Bills.Infrastructure.Commands.Base
{
    internal abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; 
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter) { throw new NotImplementedException(); }

        public void Execute(object parameter) { throw new NotImplementedException(); }       
    }
}
