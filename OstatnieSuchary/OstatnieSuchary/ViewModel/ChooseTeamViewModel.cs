using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OstatnieSuchary.Model;


namespace OstatnieSuchary.ViewModel
{
	public class ChooseTeamViewModel : Model.ViewModel
	{
		public ChooseTeamViewModel()
		{
			TemplateAnimals = new ObservableCollection<Animal>();
			_templateAnimals.Add(new Hippo(""));
            _templateAnimals.Add(new Monkey(""));
            _templateAnimals.Add(new Lion(""));
            _templateAnimals.Add(new Pinguins(""));
            _templateAnimals.Add(new Lemur(""));
		}

		private ObservableCollection<Animal> _templateAnimals;

		public ObservableCollection<Animal> TemplateAnimals
		{
			get { return _templateAnimals; }
			set
			{
				if (_templateAnimals != value)
				{
					_templateAnimals = value;
					OnPropertyChanged();
				}
			}
		}

        private ObservableCollection<Animal> _choosenAnimals = new ObservableCollection<Animal>();

        public ObservableCollection<Animal> ChoosenAnimals
        {
            get { return _choosenAnimals; }
            set
            {
                if (_choosenAnimals != value)
                {
                    _choosenAnimals = value;
                    OnPropertyChanged();
                }
            }
        }
	}
}
