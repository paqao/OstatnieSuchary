using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstatnieSuchary.ViewModel;

namespace OstatnieSuchary
{
	public class GameManager
	{
		private GameManager()
		{
			
		}

		private static GameManager _instance;
		private MatchViewModel _match;

		public static GameManager Instance
		{
			get
			{
				if (_instance == null)
					_instance = new GameManager();
				return _instance;
			}
		}

		public MatchViewModel Match
		{
			get { return _match; }
			set { _match = value; }
		}
	}
}
