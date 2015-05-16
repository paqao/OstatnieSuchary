﻿using System;
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
	}
}
