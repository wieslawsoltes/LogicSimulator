// Copyright (c) Wiesław Šoltés. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Logic.ViewModels
{
    using System;
    using System.Windows.Input;

    public class UICommand : ICommand
    {
        public Predicate<object> CanExecutePredicate { get; set; }
        public Action<object> ExecuteCommandAction { get; set; }

        public UICommand(Action<object> executeCommandAction)
        {
            ExecuteCommandAction = executeCommandAction;
        }

        public UICommand(Predicate<object> canExecutePredicate, Action<object> executeCommandAction)
        {
            CanExecutePredicate = canExecutePredicate;
            ExecuteCommandAction = executeCommandAction;
        }

        public bool CanExecute(object parameter)
        {
            if (CanExecutePredicate != null)
                return CanExecutePredicate(parameter);

            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if (ExecuteCommandAction != null)
                ExecuteCommandAction(parameter);
        }
    }
}
