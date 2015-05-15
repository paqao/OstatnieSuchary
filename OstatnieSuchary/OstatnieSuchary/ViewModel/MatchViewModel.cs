using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstatnieSuchary.Model;

namespace OstatnieSuchary.ViewModel
{
	public class MatchViewModel : Model.ViewModel
	{
		private TeamViewModel _homeTeamVM;
		private TeamViewModel _awayTeamVM;

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
	}
}
