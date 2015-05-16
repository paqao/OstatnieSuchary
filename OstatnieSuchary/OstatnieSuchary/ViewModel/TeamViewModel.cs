using OstatnieSuchary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.ViewModel
{
	public class TeamViewModel : Model.ViewModel
	{
        public ObservableCollection<Animal> TeamList { get; set; }
        private Animal[] _team;
        int choosedAnimals = 0;

        public string TeamName { get; set; }
        public Guid ID { get; set; }

        public TeamViewModel(string teamName)
        {
            _team = new Animal[5];
            TeamName = teamName;
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
