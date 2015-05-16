using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
	public class BallViewModel : ViewModel
	{
		private int _positionX;

		public int PositionX
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

		private int _positionY;

		public int PositionY
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
	}
}
