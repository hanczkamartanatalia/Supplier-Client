using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client.Commands
{
    internal class RelayCommand:ICommand
    {
        readonly Action<object> _execute; // delegaty
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) // nowy objekt
            : this(execute, null){}

        public RelayCommand(Action<object> execute, // konstruktor jeśli tworzymy nowy objekt klasy
            Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) 
        {
            return _canExecute == null || _canExecute
               (parameter);
        }

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

        public void Execute(object parameter) // wywyołuje
        {
            _execute(parameter);
        }


    }
}
