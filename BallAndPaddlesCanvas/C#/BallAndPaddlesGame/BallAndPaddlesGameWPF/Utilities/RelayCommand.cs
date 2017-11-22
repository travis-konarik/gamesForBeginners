using System;
using System.Windows.Input;

namespace BallAndPaddlesGameWPF.Utilities
{
    /// <summary>
    /// Follows ICommand interface. Allows method to be called from a command
    /// </summary>
    class RelayCommand : ICommand
    {
        /// <summary>
        /// delegate to hold a method to determine if the RelayCommand should be executed
        /// </summary>
        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// delegate that holds the method the command runs when executed
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// default constructor
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// constructor with delegate for execute and canExecute
        /// </summary>
        /// <param name="execute">method to run when command is exectued</param>
        /// <param name="canExecute">method to determine if the command should be executed</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Executes the method that verifies if the command should be executed
        /// </summary>
        /// <param name="parameters">parameters for the canExecute delegate</param>
        /// <returns>true if the command should be executed</returns>
        public bool CanExecute(object parameters)
        {
            // if _canExecute is null return true, otherwise execute _canExecute with parameters
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// runs the method in the _execute delegate
        /// </summary>
        /// <param name="parameters">parameters for the execute delegate</param>
        public void Execute(object parameters)
        {
            if (_execute == null)
                throw new ArgumentNullException("You must pass a method to RelayCommand");

            _execute(parameters);        }

    }
}