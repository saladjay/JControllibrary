using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test.BaseClass
{
    /// <summary>
    /// Delegatecommand，这种WPF.SL都可以用，VIEW里面直接使用INTERACTION的trigger激发。比较靠谱，适合不同的UIElement控件
    /// </summary>
    public class DelegateCommand : ICommand
    {
        Func<object, bool> canExecute;
        Action<object> executeAction;
        bool canExecuteCache;

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> executeAction)
        : this(executeAction, null) { }

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            if (canExecute == null) return true;

            bool temp = canExecute(parameter);

            if (canExecuteCache != temp)
            {
                canExecuteCache = temp;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }

            return canExecuteCache;
        }

        //public bool CanExecute(object parameter)
        //{
        //    return canExecute == null ? true : canExecute(parameter);
        //}

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            executeAction(parameter);
        }

        #endregion
    }
}
