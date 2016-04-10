using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDeClasses
{
    public class GestureRecognizedEventArgs : EventArgs
    {
        public string nomGeste
        {
            get;
            private set;
        }

        public Gesture.GestureType typeGeste
        {
            get;
            private set;
        }

        public GestureRecognizedEventArgs(string nom, Gesture.GestureType type = Gesture.GestureType.Unknown)
        {
            nomGeste = nom;
            typeGeste = type;
        }
    }
}
