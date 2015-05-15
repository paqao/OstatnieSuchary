﻿using System;
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
		private long _homeResult;
		private long _awayResult;
		private long _turn;

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
	}
}
