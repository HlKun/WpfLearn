using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Command_WPF
{
    public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> excute) : this(excute, null)
        {
        }

        public RelayCommand(Action<object> excute, Func<object, bool> canExcute)
        {
            _excute = excute;
            _canexcute = canExcute;
        }

        private readonly Action<object> _excute;
        private readonly Func<object, bool> _canexcute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canexcute == null || _canexcute(parameter);
        }

        public void Execute(object parameter)
        {
            _excute?.Invoke(parameter);
        }
    }
}
