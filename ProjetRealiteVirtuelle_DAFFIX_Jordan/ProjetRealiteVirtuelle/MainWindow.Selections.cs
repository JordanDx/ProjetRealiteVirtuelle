using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDeClasses;

namespace ProjetRealiteVirtuelle
{
    public partial class MainWindow
    {
        Dictionary<string, ElemType> sélections = new Dictionary<string, ElemType>()
        {
            {"LeftHandUpPosture", ElemType.Feu},
            {"BrasTendusADroitePosture", ElemType.Eau},
            //{"BrasTendusAGauchePosture", ElemType.Terre} //pourra servir pour un éventuel futur élément
            {"GestureTerre", ElemType.Terre}
        };
    }
}
