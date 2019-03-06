using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HMIS
{
    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public DelegateCommand(Action execute)
            : this(execute, () => true)
        {
            _execute = execute;
        }
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public void Execute(object parameter)
        {
            _execute();
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }
        public event EventHandler CanExecuteChanged;

    }
}
