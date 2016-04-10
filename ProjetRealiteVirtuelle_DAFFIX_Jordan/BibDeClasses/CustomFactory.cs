using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDeClasses
{
    public interface CustomFactory
    {
        Posture creerPosture();
        GesteDynamique creerGesteDynamique();
    }
}
