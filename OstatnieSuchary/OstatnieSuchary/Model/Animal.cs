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

		public decimal Power;
		public decimal Defence;
		public decimal Accurance;
		public decimal Dash;
		private bool _hasBall;
		private ICommand _kickCommand;
		private ICommand _passCommand;
		private ICommand _sprintCommand;
		private ICommand _defenceButton;
		private ICommand _dashButton;
		private ICommand _waitButton;
		private BitmapImage _image;

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
			get { return _image; }
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

		public ICommand WaitButton
		{
			get { return _waitButton; }
			set
			{
				if (_waitButton != value)
				{
					_waitButton = value;
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
