using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
    class Lion : Animal
    {
        string imgPath = "../Assets/lion200.png";

        public Lion(string name) : base(name, AnimalType.Lion)
		{
        }
    }
}
