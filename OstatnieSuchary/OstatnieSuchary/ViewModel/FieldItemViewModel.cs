using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using OstatnieSuchary.Model;

namespace OstatnieSuchary.ViewModel
{
	public class FieldItemViewModel : Model.ViewModel
	{
		private MatchViewModel _matchViewModel;

		private int positionX;
		private int positionY;
		private ICommand _fieldCommand;
		private Animal _animalAtField;
		private BallViewModel _ballAtField;
		private BitmapImage _image;
		private bool _inSprintRange;
		private bool _isEnabled;
		private bool _containsBall;
		private Random radom;
		private bool _inPassRange;

		public FieldItemViewModel(MatchViewModel matchViewModel, int positionX, int positionY)
		{
			_matchViewModel = matchViewModel;
			this.positionX = positionX;
			this.positionY = positionY;
			FieldCommand = new RelayCommand(fieldCommandAction);
			radom = new Random();
		}

		private void fieldCommandAction(object obj)
		{
			if (!this.InSprintRange && !this.InPassRange)
				return;

			var match = GameManager.Instance.Match;
			switch (match.ActionStatus)
			{
				case ActionStatus.SprintBeforePass:
				case ActionStatus.SprintBeforeShoot:
                case ActionStatus.Sprint:
				{
					var activeAnimal = GameManager.Instance.Match.ActiveAnimal;
					long previousX = activeAnimal.PositionX;
					long previousY = activeAnimal.PositionY;
                    GameManager.Instance.Match.FieldItemViewModels[(int)(previousX + 30* previousY)].AnimalAtField = null;
					if (activeAnimal.HasBall)
					{
						GameManager.Instance.Match.FieldItemViewModels[(int)(previousX + 30 * previousY)].BallAtField = null;
					}
					GameManager.Instance.Match.ActiveAnimal.PositionX = this.PositionX;
					GameManager.Instance.Match.ActiveAnimal.PositionY = this.PositionY;
					this.AnimalAtField = activeAnimal;
					if (activeAnimal.HasBall)
					{
						GameManager.Instance.Match.FieldItemViewModels[(int) (PositionX + 30*PositionY)].BallAtField = activeAnimal.Ball;
						activeAnimal.Ball.PositionY = PositionY;
						activeAnimal.Ball.PositionX = PositionX;
					}
					else
					{
						activeAnimal.Ball = BallAtField;
					}

					GameManager.Instance.Match.RefreshState();
					if (match.ActionStatus == ActionStatus.Sprint)
					{
						match.ActionStatus = ActionStatus.None;
						GameManager.Instance.Match.EndTurn();
						
					}
					else if (match.ActionStatus == ActionStatus.SprintBeforePass)
					{
						match.ActionStatus = ActionStatus.Pass;
						var animal = GameManager.Instance.Match.ActiveAnimal;
						int range = (int)Math.Sqrt((double)animal.Power / 20.0f);
						animal.IsAtSemiAction = true;
						animal.MarkInPassRange(animal.PositionY, range, animal.PositionX, animal.PositionX + animal.PositionY * 30);
					}
					else if (match.ActionStatus == ActionStatus.SprintBeforeShoot)
					{
						match.ActionStatus = ActionStatus.Shoot;
						var animal = GameManager.Instance.Match.ActiveAnimal;
						int range = (int)Math.Sqrt((double)animal.Power / 15.0f);
						animal.IsAtSemiAction = true;
						animal.MarkInPassRange(animal.PositionY, range, animal.PositionX, animal.PositionX + animal.PositionY * 30);
					}

						break;
				}
				case ActionStatus.Shoot:
                case ActionStatus.Pass:
				{
					match.ActionStatus = ActionStatus.None;

					long previousX = GameManager.Instance.Match.BallViewModel.PositionX;
					long previousY = GameManager.Instance.Match.BallViewModel.PositionY;
					
					GameManager.Instance.Match.ActiveAnimal.Ball = null;
					GameManager.Instance.Match.ActiveAnimal.IsAtSemiAction = false;

					var activeAnimal = GameManager.Instance.Match.ActiveAnimal;
					var accuracy = match.ActionStatus == ActionStatus.Shoot ? 0.7M * activeAnimal.Accuracy : activeAnimal.Accuracy;

					double diff = Math.Sqrt((110 - (double) accuracy)/1.25f);
					
                    var diffX =(int) ( (-0.5 + radom.NextDouble()) * diff);
					var diffY = (int)((-0.5 + radom.NextDouble()) * diff);

					var newPositionX = PositionX + diffX;
					var newPositionY = PositionY + diffY;
					GameManager.Instance.Match.BallViewModel.PositionX = newPositionX;
					GameManager.Instance.Match.BallViewModel.PositionY = newPositionY;
					
					var previousField = GameManager.Instance.Match.FieldItemViewModels[(int)(previousX + 30 * previousY)];
					previousField.BallAtField = null;

					var destinationField = GameManager.Instance.Match.FieldItemViewModels[(int) (newPositionX + 30* newPositionY)];

					destinationField.BallAtField = GameManager.Instance.Match.BallViewModel;
					GameManager.Instance.Match.RefreshState();

					if (destinationField.AnimalAtField != null)
					{
						destinationField.AnimalAtField.Ball = BallAtField;
					}

					GameManager.Instance.Match.EndTurn();
					break;
				}
			}
		}

		public BallViewModel BallAtField
		{
			get
			{
				return _ballAtField;
			}
			set
			{
				if (_ballAtField != value)
				{
					_ballAtField = value;
					OnPropertyChanged();
					OnPropertyChanged("ContainsBall");
					OnPropertyChanged("Instance");
					OnPropertyChanged("Image");
				}
			}
		}

		public Animal AnimalAtField
		{
			get { return _animalAtField; }
			set
			{
				if (_animalAtField != value)
				{
					_animalAtField = value;
					OnPropertyChanged();
					OnPropertyChanged("Instance");
					OnPropertyChanged("Image");
				}
			}
		}

		public bool InSprintRange
		{
			get { return _inSprintRange; }
			set
			{
				if (_inSprintRange != value)
				{
					_inSprintRange = value;
					OnPropertyChanged();
					OnPropertyChanged("Instance");
				}
			}
		}

		public FieldItemViewModel Instance
		{
			get
			{
				return this;
			}
		}

		public BitmapImage Image
		{
			get
			{
				if (AnimalAtField == null)
				{
					return null;
				}
				return AnimalAtField.Image;
			}
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

		public bool IsEnabled
		{
			get { return _isEnabled; }
			set
			{
				if (_isEnabled != value)
				{
					_isEnabled = value;
					OnPropertyChanged();
				}
			}
		}

		public bool ContainsBall
		{
			get { return BallAtField != null; }
		}

		public bool InPassRange
		{
			get { return _inPassRange; }
			set
			{
				if (_inPassRange != value)
				{
					_inPassRange = value;
					OnPropertyChanged();
					OnPropertyChanged("Instance");
				}
			}
		}

		public void Refresh()
		{
			OnPropertyChanged("Instance");
		}
	}
}
