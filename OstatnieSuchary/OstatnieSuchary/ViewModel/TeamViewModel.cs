using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace OstatnieSuchary.ViewModel
{
	public class TeamViewModel : Model.ViewModel
	{
		private string _teamName;
		private Brush _teamColor;


		public string TeamName
		{
			get { return _teamName; }
			set
			{
				if (_teamName != value)
				{
					_teamName = value;
					OnPropertyChanged();
				}
			}
		}

		public Brush TeamColor
		{
			get { return _teamColor;}
			set
			{
				if (_teamColor != value)
				{
					_teamColor = value;
					OnPropertyChanged();
				}
			}
		}
	}
}
