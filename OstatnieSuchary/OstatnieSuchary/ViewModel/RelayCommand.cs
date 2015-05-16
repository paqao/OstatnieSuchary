using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OstatnieSuchary.ViewModel
{
	public class RelayCommand : ICommand
	{
		private Predicate<object> _canExecute;
		private Action<object> _execute;

		public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
		{
			if (execute == null)
			{
				throw new ArgumentNullException("execute");
			}
			_execute = execute;
			_canExecute = canExecute;
			_previousExecutionState = false;
		}

		private bool _previousExecutionState;

		public bool CanExecute(object parameter)
		{
			if (_canExecute == null)
				return true;

			bool actualExecution = _canExecute(parameter);

			if (actualExecution != _previousExecutionState)
			{
				_previousExecutionState = actualExecution;
				if (CanExecuteChanged != null)
				{
					CanExecuteChanged(this,EventArgs.Empty);
				}
			}

			return _previousExecutionState;
		}

		public void Execute(object parameter)
		{
			if (CanExecute(parameter))
			{
				_execute(parameter);
			}
		}

		public event EventHandler CanExecuteChanged;
	}
}
