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
        Dictionary<string, Action<Joueur, Joueur, MainWindow>> actions = new Dictionary<string, Action<Joueur, Joueur, MainWindow>>()
        {
            {"BrasTendusPosture", (joueur, joueurAdverse, mw) => joueur.Attaquer(joueurAdverse, mw)},
            {"BrasCroisesPosture", (joueur, joueurAdverse, mw) => joueur.AfficherBouclier(mw)},
        };
    }
}
