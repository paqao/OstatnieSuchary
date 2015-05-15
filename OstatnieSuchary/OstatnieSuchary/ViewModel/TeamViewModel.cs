using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.ViewModel
{
	public class TeamViewModel : Model.ViewModel
	{
		private string _teamName;

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
	}
}
