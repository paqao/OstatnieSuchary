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
			GameManager.Instance.Match.FieldItemViewModels[(int)(animal.PositionX + animal.PositionY * 30)].AnimalAtField = animal;
			TeamList.Add(animal);
        }

		private IEnumerator<Animal> _enumerableElements; 
		public bool MoveNext()
		{
			if (_enumerableElements.MoveNext())
			{
				if (GameManager.Instance.Match.ActiveAnimal != null)
				{
					var prev = GameManager.Instance.Match.ActiveAnimal;
					prev.IsActive = false;
					var field = GameManager.Instance.Match.FieldItemViewModels[(int) (prev.PositionY*30 + prev.PositionX)];
					field.Refresh();
				}

				GameManager.Instance.Match.ActiveAnimal = _enumerableElements.Current;
			
				var prev2 = GameManager.Instance.Match.ActiveAnimal;
				prev2.IsActive = true;
				var field2 = GameManager.Instance.Match.FieldItemViewModels[(int)(prev2.PositionY * 30 + prev2.PositionX)];
				field2.Refresh();
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
