using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
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
		private ActionStatus _actionStatus;
		private BallViewModel _ballViewModel;

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

			Turn = 1;
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					FieldItemViewModel newFieldItemViewModel = new FieldItemViewModel(this, j, i);
					this.FieldItemViewModels.Add(newFieldItemViewModel);
				}
			}
			
			
		}

		public void Initialize()
		{
			TeamViewModel team1 = new TeamViewModel();
			Animal ani = new Hippo("moj hippo");

			ani.PositionX = 7;
			ani.PositionY = 1;
			ani.IsActive = true;
			ani.HasBall = true;
			team1.AddAnimal(ani);


			ani = new Hippo("moj hippo2");
			ani.PositionX = 13;
			ani.PositionY = 7;
			team1.AddAnimal(ani);


			HomeTeamVM = team1;

			#region team 2
			TeamViewModel team2 = new TeamViewModel();
			Animal ani2 = new Hippo("moj hippo");

			ani2.PositionX = 25;
			ani2.PositionY = 11;
			team2.AddAnimal(ani2);
			AwayTeamVM = team2;

			#endregion
			_activeTeam = HomeTeamVM;
			team1.StartsTurn();
			EndTurn();

			_ballViewModel = new BallViewModel();
			_activeAnimal.Ball = _ballViewModel;
			_ballViewModel.PositionX = (int)_activeAnimal.PositionX;
			_ballViewModel.PositionY = (int) _activeAnimal.PositionY;
			_fieldItemViewModels[30*_ballViewModel.PositionY + _ballViewModel.PositionX].BallAtField = BallViewModel;

			OnAwayScoreCommand =new RelayCommand(async x =>
			{
				
				MessageDialog dialog = new MessageDialog("bkeee");
				await dialog.ShowAsync();
			}, x => ShotAtAway());

			OnHomeScoreCommand = new RelayCommand(async x =>
			{

				MessageDialog dialog = new MessageDialog("bkeee");
				await dialog.ShowAsync();
			}, x => ShotAtHome());
		}

		private bool ShotAtHome()
		{
			return ActionStatus == ActionStatus.Pass || ActionStatus == ActionStatus.Shoot;
		}

		public RelayCommand OnHomeScoreCommand
		{
			get { return _onHomeScoreCommand; }
			set
			{
				if (_onHomeScoreCommand != value)
				{
					_onHomeScoreCommand = value;
					OnPropertyChanged();
				}
			}
		}

		private bool ShotAtAway()
		{
			return ActionStatus == ActionStatus.Pass || ActionStatus == ActionStatus.Shoot;
		}

		public BallViewModel BallViewModel
		{
			get
			{
				return _ballViewModel;
			}
			set
			{
				if (_ballViewModel != value)
				{
					_ballViewModel = value;
					OnPropertyChanged();
				}
			}
		}

		private TeamViewModel _activeTeam;
		private ICommand _onAwayScoreCommand;
		private RelayCommand _onHomeScoreCommand;

		public void EndTurn()
		{
			bool tryNext = _activeTeam.MoveNext();
			if (!tryNext)
			{
				if (_activeTeam == AwayTeamVM)
				{
					Turn++;
				}
				_activeTeam = _activeTeam == AwayTeamVM ? HomeTeamVM : AwayTeamVM;
				_activeTeam.StartsTurn();
				_activeTeam.MoveNext();
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

		public ActionStatus ActionStatus
		{
			get { return _actionStatus; }
			set
			{
				if (_actionStatus != value)
				{
					_actionStatus = value;
					
					OnAwayScoreCommand.CanExecute(null);
					OnHomeScoreCommand.CanExecute(null);

					OnPropertyChanged();
				}
			}
		}

		public void RefreshState()
		{
			foreach (var field in FieldItemViewModels)
			{
				field.InSprintRange = false;
				field.InPassRange = false;
			}
		}

		public ICommand OnAwayScoreCommand
		{
			get { return _onAwayScoreCommand; }
			set
			{
				if (_onAwayScoreCommand != value)
				{
					_onAwayScoreCommand = value;
					OnPropertyChanged();
				}
			}
		}
    }

	public enum ActionStatus
	{
		None, Sprint, SprintBeforePass,
		Pass,
		SprintBeforeShoot,
		Shoot
	}
}
