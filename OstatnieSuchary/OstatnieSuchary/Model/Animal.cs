using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Media.Imaging;
using OstatnieSuchary.ViewModel;

namespace OstatnieSuchary.Model
{
	public abstract class Animal : ViewModel
	{
		private string _name;
		private AnimalType _type;
        public Guid Id { get; set; }

		public long PositionX
		{
			get { return _positionX; }
			set
			{
				if (_positionX != value)
				{
					_positionX = value;
					OnPropertyChanged();
				}
			}
		}

		public long PositionY
		{
			get { return _positionY; }
			set
			{
				if (_positionY != value)
				{
					_positionY = value;
					OnPropertyChanged();
				}
			}
		}

		protected void LoadImage(string path)
		{
			Image = new BitmapImage(new Uri(path));
		}

		public Animal(string name, AnimalType type )
		{
			Name = name;
			Type = type;

			KickCommand = new RelayCommand(async x =>
			{
				MessageDialog dialog = new MessageDialog("Kick");
				await dialog.ShowAsync();
			});

			PassCommand = new RelayCommand(async x =>
			{
				MessageDialog dialog = new MessageDialog("Pass");
				await dialog.ShowAsync();
			});

			SprintCommand = new RelayCommand(x =>
			{
				GameManager.Instance.Match.ActionStatus = ActionStatus.Sprint;

				var modifiedSpeed = this.Speed;
				if (HasBall)
					modifiedSpeed = modifiedSpeed*3/4;
				int range = (int) Math.Sqrt((double)modifiedSpeed / 20.0f);

				long actualPos = CalculateActualPosition(PositionX, PositionY);
				
				long minY = PositionY - range;
	
				for (int i = 0; i <= 2*range; i++)
				{
					if (i + minY < 0)
					{
						continue;
					}

					if (i + minY >= 20)
					{
						continue;
					}

					// center = i == range;
					long delta;
					if (i <= range)
					{
						delta = i;
					}
					else
					{
						delta = 2*range - i;
					}
					long minX = PositionX - delta;
					long maxX = PositionX + delta;

					
					for (long j = minX; j <= maxX; j++)
					{
						if(j < 0 || j > 29)
							continue;

						long position = CalculateActualPosition(j, minY + i);
						
						if(position == actualPos)
							continue;

						var currentField = GameManager.Instance.Match.FieldItemViewModels[(int) position];
						currentField.InSprintRange = true;
						currentField.IsEnabled = true;
					}
				}
			});

			WaitButtonCommand = new RelayCommand(x =>
			{
				GameManager.Instance.Match.EndTurn();
			});


		}

		private long CalculateActualPosition(long posX, long posY)
		{
			return posY * 30 + posX;
		}

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if(_name != value)
				{
					_name = value;
					OnPropertyChanged();
				}
			}
		}

		public decimal Speed;

		public bool HasBall
		{
			get { return _hasBall; }
			set
			{
				if (_hasBall != value)
				{
					_hasBall = value;
					OnPropertyChanged();
				}
			}
		}

		public bool IsActive
		{
			get { return _isActive; }
			set
			{
				if (_isActive != value)
				{
					_isActive = value;
					OnPropertyChanged();
				}
			}
		}

		public decimal Power;
		public decimal Defence;
		public decimal Accuracy;
		public decimal Dash;
		private bool _hasBall;
		private ICommand _kickCommand;
		private ICommand _passCommand;
		private ICommand _sprintCommand;
		private ICommand _defenceButton;
		private ICommand _dashButton;
		private ICommand _waitButtonCommand;
		private BitmapImage _image;
		private bool _isActive;
		private long _positionX;
		private long _positionY;

		public AnimalType Type
		{
			get
			{
				return _type;
			}
			set
			{
				if(_type != value)
				{
					_type = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand KickCommand
		{
			get { return _kickCommand; }
			set
			{
				if (_kickCommand != value)
				{
					_kickCommand = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand PassCommand
		{
			get { return _passCommand; }
			set
			{
				if (_passCommand != value)
				{
					_passCommand = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand SprintCommand
		{
			get { return _sprintCommand; }
			set
			{
				if (_sprintCommand != value)
				{
					_sprintCommand = value;
					OnPropertyChanged();
				}
			}
		}

		public BitmapImage Image
		{
			get
			{
				return _image;
			}
			set
			{
				if (_image != value)
				{
					_image = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand DefenceButton
		{
			get { return _defenceButton; }
			set
			{
				if (_defenceButton != value)
				{
					_defenceButton = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand DashButton
		{
			get { return _dashButton; }
			set
			{
				if (_dashButton != value)
				{
					_dashButton = value;
					OnPropertyChanged();
				}
			}
		}

		public ICommand WaitButtonCommand
		{
			get { return _waitButtonCommand; }
			set
			{
				if (_waitButtonCommand != value)
				{
					_waitButtonCommand = value;
					OnPropertyChanged();
				}
			}
		}
    }

	public enum AnimalType
	{
		Monkey,
		Lion,
		Hippo,
		Lemur,
		Pinguins
	}
}
