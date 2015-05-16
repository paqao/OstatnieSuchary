using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OstatnieSuchary.ViewModel
{
	public class FieldItemViewModel : Model.ViewModel
	{
		private MatchViewModel _matchViewModel;

		private int positionX;
		private int positionY;
		private ICommand _fieldCommand;

		public FieldItemViewModel(MatchViewModel matchViewModel, int positionX, int positionY)
		{
			_matchViewModel = matchViewModel;
			this.positionX = positionX;
			this.positionY = positionY;
		}

		public ICommand FieldCommand
		{
			get { return _fieldCommand; }
			set
			{
				if (_fieldCommand != value)
				{
					_fieldCommand = value;
					OnPropertyChanged();
				}
			}
		}

		public int PositionX
		{
			get { return positionX; }
			set
			{
				if (positionX != value)
				{
					positionX = value;
					OnPropertyChanged();
				}
			}
		}

		public int PositionY
		{
			get { return positionY; }
			set
			{
				if (positionY != value)
				{
					positionY = value;
					OnPropertyChanged();
				}
			}
		}

		public override string ToString()
		{
			return positionX + " " + positionY;
		}
	}
}
