using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
    class Pinguins : Animal
    {
        string imgPath = "../Assets/penguin200.png";

        public Pinguins(string name) : base(name, AnimalType.Pinguins)
		{
        }
    }
}
