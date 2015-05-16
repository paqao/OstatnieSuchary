using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstatnieSuchary.Annotations;
using OstatnieSuchary.Model;

namespace OstatnieSuchary.ViewModel
{
	public class MatchViewModel : Model.ViewModel
	{
		private TeamViewModel _homeTeamVM;
		private TeamViewModel _awayTeamVM;
		private long _homeResult;
		private long _awayResult;
		private long _turn;
		private Animal _activeAnimal;

		private long[,] _fields;
		private List<FieldItemViewModel> _fieldItemViewModels;
		private bool _busy;

		public List<FieldItemViewModel> FieldItemViewModels
		{
			get
			{
				return _fieldItemViewModels;
			}
		} 

		public MatchViewModel()
		{
			_fields = new long[20,30];
			_fieldItemViewModels = new List<FieldItemViewModel>();
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					FieldItemViewModel newFieldItemViewModel = new FieldItemViewModel(this, j, i);
					this.FieldItemViewModels.Add(newFieldItemViewModel);
				}
			}
		}

		public TeamViewModel HomeTeamVM
		{
			get { return _homeTeamVM; }
			set
			{
				if (_homeTeamVM != value)
				{
					_homeTeamVM = value;
					OnPropertyChanged();
				}
			}
		}

		public long HomeResult
		{
			get { return _homeResult; }
			set
			{
				if (_homeResult != value)
				{
					_homeResult = value;
					OnPropertyChanged();
				}
			}
		}

		public long AwayResult
		{
			get { return _awayResult; }
			set
			{
				if (_awayResult != value)
				{
					_awayResult = value;
					OnPropertyChanged();
				}
			}
		}

		public TeamViewModel AwayTeamVM {
			get
			{
				return _awayTeamVM;
			}
			set
			{
				if (_awayTeamVM != value)
				{
					_awayTeamVM = value;
					OnPropertyChanged();
				}
			}
		}

		public long Turn
		{
			get { return _turn; }
			set
			{
				if (_turn != value)
				{
					_turn = value;
					OnPropertyChanged();
				}
			}
		}

		public Animal ActiveAnimal
		{
			get { return _activeAnimal; }
			set
			{
				if (_activeAnimal != value)
				{
					_activeAnimal = value;
					OnPropertyChanged();
				}
			}
		}

		public bool Busy
		{
			get { return _busy; }
			set
			{
				if (_busy != value)
				{
					_busy = value;
					OnPropertyChanged();
				}
			}
		}
	}
}
