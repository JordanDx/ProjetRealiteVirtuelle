using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibDeClasses;
using System.Windows;


namespace ProjetRealiteVirtuelle
{
    public partial class MainWindow
    {
        static Dictionary<ElemType, ElemType> elementsContrant = new Dictionary<ElemType, ElemType>()
        {
            {ElemType.Feu, ElemType.Eau},
            {ElemType.Eau, ElemType.Terre},
            {ElemType.Terre, ElemType.Feu},
        };

        public Dictionary<ElemType, ElemType> ElementsContrant
        {
            get
            {
                return elementsContrant;
            }
        }
    }
}
