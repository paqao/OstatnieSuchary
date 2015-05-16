using OstatnieSuchary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.ViewModel
{
    class AnimalsCollectionViewModel : Model.ViewModel
    {
        public ObservableCollection<Animal> AllAnimalsCollection { get; set; }

        public AnimalsCollectionViewModel()
        {
            AllAnimalsCollection = new ObservableCollection<Animal>();
            //AllAnimalsCollection.Add(new Lemoor(:D));
            //AllAnimalsCollection.Add(new Lemoor(:D));
            //AllAnimalsCollection.Add(new Lemoor(:D));
        }

    }
}
