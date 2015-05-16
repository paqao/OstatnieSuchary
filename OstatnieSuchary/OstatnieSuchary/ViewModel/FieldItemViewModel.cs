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
		private BitmapImage _image;
		private bool _inSprintRange;
		private bool _isEnabled;
		private bool _containsBall;

		public FieldItemViewModel(MatchViewModel matchViewModel, int positionX, int positionY)
		{
			_matchViewModel = matchViewModel;
			this.positionX = positionX;
			this.positionY = positionY;
			FieldCommand = new RelayCommand(fieldCommandAction);
		}

		private void fieldCommandAction(object obj)
		{
			if (!this.InSprintRange)
				return;

			var match = GameManager.Instance.Match;
			switch (match.ActionStatus)
			{
				case ActionStatus.Sprint:
				{
					long previousX = GameManager.Instance.Match.ActiveAnimal.PositionX;
					long previousY = GameManager.Instance.Match.ActiveAnimal.PositionY;
                    GameManager.Instance.Match.FieldItemViewModels[(int)(previousX + 30* previousY)].AnimalAtField = null;
					GameManager.Instance.Match.ActiveAnimal.PositionX = this.PositionX;
					GameManager.Instance.Match.ActiveAnimal.PositionY = this.PositionY;
					GameManager.Instance.Match.RefreshState();
					this.AnimalAtField = GameManager.Instance.Match.ActiveAnimal;
					match.ActionStatus =ActionStatus.None;
					GameManager.Instance.Match.EndTurn();
					break;
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
			get { return _containsBall; }
			set
			{
				if (_containsBall != value)
				{
					_containsBall = value;
					OnPropertyChanged();
				}
			}
		}

		public void Refresh()
		{
			OnPropertyChanged("Instance");
		}
	}
}
