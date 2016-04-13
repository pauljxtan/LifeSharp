using System;
using System.Windows.Input;

namespace LifeSharp.ViewModel
{
    /// <summary>
    /// Binds commands in the view.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// An Action delegate encapsulating the command to execute.
        /// </summary>
        private readonly Action _action;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
