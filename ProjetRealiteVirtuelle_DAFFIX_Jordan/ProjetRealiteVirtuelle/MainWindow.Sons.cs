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

        static Dictionary<ElemType, string> sonsElements = new Dictionary<ElemType, string>()
        {
            {ElemType.Feu, "ElementFeuPret.mp3"},
            {ElemType.Eau, "ElementEauPret.mp3"},
            {ElemType.Terre, "ElementTerrePret.mp3"},
        };

        public Dictionary<ElemType, string> SonsElements
        {
            get
            {
                return sonsElements;
            }
        }



        static Dictionary<ElemType, string> sonsBoules = new Dictionary<ElemType, string>()
        {
            {ElemType.Feu, "BouleFeu.mp3"},
            {ElemType.Eau, "BouleEau.mp3"},
            {ElemType.Terre, "BouleTerre.mp3"},
        };

        public Dictionary<ElemType, string> SonsBoules
        {
            get
            {
                return sonsBoules;
            }
        }

    }
}
