using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstatnieSuchary.Model
{
    class Lemur : Animal
    {
        string imgPath = "ms-appx:///Assets/lemur200.png";

        public Lemur(string name) : base(name, AnimalType.Lemur)
        {
            LoadImage(imgPath);
        }
    }
}
