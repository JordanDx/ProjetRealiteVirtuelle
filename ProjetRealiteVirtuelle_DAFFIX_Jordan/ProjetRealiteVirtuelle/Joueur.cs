using BibDeClasses;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace ProjetRealiteVirtuelle
{
    public class Joueur
    {

        public ElemType typeCurrentElement
        {
            get;
            set;
        }

        public int vie
        {
            get;
            set;
        }

        public ElemType elementBouclierPret
        {
            get;
            set;
        }

  

        

        public virtual void ElementPret(ElemType elemType, MainWindow mw)
        {
            typeCurrentElement = elemType;
            PostureMageBrasLeves(mw);
            mw.MediaPlayerSons.Open(new Uri(string.Format(@"../../Sons/ElementsPrets/{0}", mw.SonsElements[elemType]), UriKind.Relative));
            mw.MediaPlayerSons.Play();
            RemiseAZeroBouclier(mw);
        }


        public virtual void AfficherBouclier(MainWindow mw)
        {
            elementBouclierPret = typeCurrentElement;
            RemiseAZeroElementPret(mw);
        }

        public virtual void RemiseAZeroBouclier(MainWindow mw)
        {
            elementBouclierPret = ElemType.Unknown;
        }



        public virtual void PostureMageStatique(MainWindow mw)
        {
        }
        public virtual void PostureMageBrasLeves(MainWindow mw)
        {
        }
        public virtual void PostureMageBrasTendus(MainWindow mw)
        {
        }



        public virtual void RemiseAZeroElementPret(MainWindow mw)
        {
            typeCurrentElement = ElemType.Unknown;
        }



        public virtual void Attaquer(Joueur joueurAdverse, MainWindow mw)
        {
            if (typeCurrentElement == ElemType.Unknown)
                return;
            RemiseAZeroBouclier(mw);
            PostureMageBrasTendus(mw);
            mw.MediaPlayerSons.Open(new Uri(string.Format(@"../../Sons/Boules/{0}", mw.SonsBoules[typeCurrentElement]), UriKind.Relative));
            mw.MediaPlayerSons.Play();
        }

        public virtual async void DeplacementProjectile(ProjectileUserControl projectile, MainWindow mw, Joueur joueurAdverse)
        {
            await AnimateProjectile(projectile, 4000, mw, joueurAdverse, projectile.TypeProjectile).ContinueWith(t => mw.Dispatcher.Invoke(() => mw.canvasJeu.Children.Remove(projectile)));
            PostureMageStatique(mw);
        }

        public virtual async Task AnimateProjectile(UIElement projectile, int milliseconds, MainWindow mw, Joueur joueurAdverse, ElemType typeProjectile)
        {
        }

        public virtual void RafraichirVie(MainWindow mw)
        {
            vie--;
        }

        public Joueur()
        {
            vie = 3;
        }
      
    }
}
