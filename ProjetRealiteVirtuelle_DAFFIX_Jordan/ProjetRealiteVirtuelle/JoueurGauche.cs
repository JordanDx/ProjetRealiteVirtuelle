using BibDeClasses;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ProjetRealiteVirtuelle
{
    public class JoueurGauche : Joueur
    {

        public override void ElementPret(ElemType elemType, MainWindow mw)
        {
            base.ElementPret(elemType, mw);
            foreach (var imageElt in mw.ImagesElements.Values) imageElt.Opacity = 0.4;
            mw.ImagesElements[elemType].Opacity = 1.0;
        }
    

        public override void AfficherBouclier(MainWindow mw)
        {
            if (typeCurrentElement == ElemType.Unknown)
                return;

            RemiseAZeroBouclier(mw);
            mw.ImagesBoucliers[typeCurrentElement].Visibility = System.Windows.Visibility.Visible;
            base.AfficherBouclier(mw);
        }
 

        public override void RemiseAZeroBouclier(MainWindow mw)
        {
            mw.bouclierEau.Visibility = Visibility.Hidden;
            mw.bouclierFeu.Visibility = Visibility.Hidden;
            mw.bouclierTerre.Visibility = Visibility.Hidden;
        }


        public override void PostureMageStatique(MainWindow mw)
        {
            mw.mageStatique.Visibility = System.Windows.Visibility.Visible;
            mw.mageBrasLeves.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasTendus.Visibility = System.Windows.Visibility.Hidden;
        }
        public override void PostureMageBrasLeves(MainWindow mw)
        {
            mw.mageStatique.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasLeves.Visibility = System.Windows.Visibility.Visible;
            mw.mageBrasTendus.Visibility = System.Windows.Visibility.Hidden;
        }
        public override void PostureMageBrasTendus(MainWindow mw)
        {
            mw.mageStatique.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasLeves.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasTendus.Visibility = System.Windows.Visibility.Visible;
        }



        public override void RemiseAZeroElementPret(MainWindow mw)
        {
            base.RemiseAZeroElementPret(mw);
            mw.elementFeu.Opacity = 0.4;
            mw.elementEau.Opacity = 0.4;
            mw.elementTerre.Opacity = 0.4;
        }



        public override void Attaquer(Joueur joueurAdverse, MainWindow mw)
        {
            if (typeCurrentElement == ElemType.Unknown)
                return;
            base.Attaquer(joueurAdverse, mw);
            ProjectileUserControl projectile = new ProjectileUserControl() { TypeProjectile = typeCurrentElement };
            projectile.SetValue(Canvas.LeftProperty, 140.0);
            projectile.SetValue(Canvas.BottomProperty, 140.0);
            mw.canvasJeu.Children.Add(projectile);
            DeplacementProjectile(projectile, mw, joueurAdverse);
            RemiseAZeroElementPret(mw);
            
        }

        public override async Task AnimateProjectile(UIElement projectile, int milliseconds, MainWindow mw, Joueur joueurAdverse, ElemType elementProjectile)
        {
            TranslateTransform trs = new TranslateTransform();
            DoubleAnimation anim;
            anim = new DoubleAnimation(0, mw.canvasJeu.ActualWidth - 280, TimeSpan.FromMilliseconds(milliseconds));

            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            projectile.RenderTransform = trs;
            await Task.Delay(milliseconds);

            

            if (mw.ElementsContrant[elementProjectile] != joueurAdverse.elementBouclierPret)
            {
                anim = new DoubleAnimation(mw.canvasJeu.ActualWidth - 280, mw.canvasJeu.ActualWidth - 230, TimeSpan.FromMilliseconds(400));
                trs.BeginAnimation(TranslateTransform.XProperty, anim);
                projectile.RenderTransform = trs;
                await Task.Delay(400);


                mw.MediaPlayerSons.Open(new Uri(@"../../Sons/JoueurTouche.mp3", UriKind.Relative));
                mw.MediaPlayerSons.Play();

                joueurAdverse.RafraichirVie(mw);   
            }
        }


        public override void RafraichirVie(MainWindow mw)
        {
            base.RafraichirVie(mw);
            switch (vie)
            {
                case 2:
                    mw.coeur3j1.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    mw.coeur2j1.Visibility = Visibility.Hidden;
                    break;
                case 0:
                    mw.coeur1j1.Visibility = Visibility.Hidden;
                    MessageBox.Show("Le joueur 2 a gagné !  Relancez la partie.");
                    mw.RecommencerPartie();
                    break;
            }

        }



        


    }
}
