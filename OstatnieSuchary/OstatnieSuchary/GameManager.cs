﻿using System;
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
		private ChooseTeamViewModel _teamSelector;
        private ChooseTeamViewModel _chooseTeamViewModel;

        public int animalsInTeam = 5;

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

 
        public ChooseTeamViewModel TeamSelector
        {
            get { return _teamSelector; }
            set { _teamSelector = value; }
        }

        public ChooseTeamViewModel ChooseTeamViewModel
        {
            get { return _chooseTeamViewModel; }
            set { _chooseTeamViewModel = value; }
        }
    }
}
