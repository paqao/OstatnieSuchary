using OstatnieSuchary.Model;
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
        public List<Animal> TeamList { get; set; }
		
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
	        TeamList = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
	        TeamList.Add(animal);
        }

		private IEnumerator<Animal> _enumerableElements; 
		public bool MoveNext()
		{
			if (_enumerableElements.MoveNext())
			{
				GameManager.Instance.Match.ActiveAnimal = _enumerableElements.Current;
				return true;
			}
			else
			{
				return false;
			}
		}

		public void StartsTurn()
		{
			_enumerableElements = TeamList.OrderByDescending(x => x.Speed).GetEnumerator();
			MoveNext();
		}

        public void DeleteAnimal(Guid id)
        {
	        for (int i = this.TeamList.Count - 1; i >= 0; i--)
	        {
		        if (TeamList[i].Id == id)
		        {
			        TeamList.RemoveAt(i);
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
