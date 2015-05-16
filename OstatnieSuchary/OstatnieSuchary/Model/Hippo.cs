using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
    class Hippo : Animal
    {
        string imgPath = "ms-appx:///Assets/hippo200.png";

        public Hippo(string name) : base(name, AnimalType.Hippo)
        {
	        LoadImage(imgPath);
	        Speed = 160;
	        Power = 400;
	        Accuracy = 70;
        }
    }
}
