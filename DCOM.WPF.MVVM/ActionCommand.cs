namespace DCOM.WPF.MVVM
{
    using System;
    using System.Windows.Input;

    public class ActionCommand : ICommand
    {
        private readonly Action<object> action;
        private readonly Predicate<Object> predicate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action to invoke on command.</param>
        public ActionCommand(Action<Object> action) : this(action, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action to invoke on command.</param>
        /// <param name="predicate">The predicate that determines if the action can be invoked.</param>
        public ActionCommand(Action<Object> action, Predicate<Object> predicate)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action), @"You must specify an Action<T>.");
            }

            this.action = action;
            this.predicate = predicate;
        }

        /// <summary>
        /// Occurs when the <see cref="System.Windows.Input.CommandManager"/> detects conditions that might change the ability of a command to execute.
        /// </summary>
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

        /// <summary>
        /// Determines whether the command can execute.
        /// </summary>
        /// <param name="parameter">A custom parameter object.</param>
        /// <returns>
        ///     Returns true if the command can execute, otherwise returns false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.predicate == null)
            {
                return true;
            }
            return this.predicate(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        public void Execute()
        {
            Execute(null);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">A custom parameter object.</param>
        public void Execute(object parameter)
        {
            this.action(parameter);
        }
    }
}