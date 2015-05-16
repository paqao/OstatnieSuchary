﻿using OstatnieSuchary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace OstatnieSuchary.ViewModel
{
	public class TeamViewModel : Model.ViewModel
	{
        public ObservableCollection<Animal> TeamList { get; set; }
        private Animal[] _team;
        int choosedAnimals = 0;
        
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
        public Guid ID { get; set; }

        public TeamViewModel()
        {
            _team = new Animal[5];
        }

        public void AddAnimal(Animal animal)
        {
            if(choosedAnimals<5)
            {
                _team[choosedAnimals] = animal;
                choosedAnimals++;
                TeamList = new ObservableCollection<Animal>(_team);
            }
        }

        public void DeleteAnimal(Guid id)
        {
            for (int i=0; i<4; i++)
            {
                if(_team[i].Id.CompareTo(id)==0)
                {
                    _team[i] = _team[--choosedAnimals];
                    TeamList = new ObservableCollection<Animal>(_team);
                    break;
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
