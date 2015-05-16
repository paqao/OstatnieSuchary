using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
    class Hippo : Animal
    {
        public Hippo(string name) : base(name, AnimalType.Hippo)
		{
            string imgPath = "../Assets/hippo200.png";
        }
    }
}
