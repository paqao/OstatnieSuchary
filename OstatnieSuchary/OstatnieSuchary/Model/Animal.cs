using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
