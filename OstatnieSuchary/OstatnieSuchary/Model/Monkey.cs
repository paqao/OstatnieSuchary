using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
    class Monkey : Animal
    {
        string imgPath = "../Assets/monkey200.png";

        public Monkey(string name) : base(name, AnimalType.Monkey)
		{
        }
    }
}
