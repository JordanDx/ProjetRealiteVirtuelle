using BibDeClasses;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace ProjetRealiteVirtuelle
{
    public class JoueurDroit : Joueur
    {


        public override void ElementPret(ElemType elemType, MainWindow mw)
        {
            base.ElementPret(elemType, mw);
            foreach (var imageElt in mw.ImagesElementsJoueur2.Values) imageElt.Opacity = 0.4;
            mw.ImagesElementsJoueur2[elemType].Opacity = 1.0;
        }


        public override void AfficherBouclier(MainWindow mw)
        {
            if (typeCurrentElement == ElemType.Unknown)
                return;

            RemiseAZeroBouclier(mw);
            mw.ImagesBoucliersJoueur2[typeCurrentElement].Visibility = System.Windows.Visibility.Visible;
            base.AfficherBouclier(mw);
        }


        public override void RemiseAZeroBouclier(MainWindow mw)
        {
            mw.bouclierEau2.Visibility = Visibility.Hidden;
            mw.bouclierFeu2.Visibility = Visibility.Hidden;
            mw.bouclierTerre2.Visibility = Visibility.Hidden;
        }




        public override void PostureMageStatique(MainWindow mw)
        {
            mw.mageStatique2.Visibility = System.Windows.Visibility.Visible;
            mw.mageBrasLeves2.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasTendus2.Visibility = System.Windows.Visibility.Hidden;
        }
        public override void PostureMageBrasLeves(MainWindow mw)
        {
            mw.mageStatique2.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasLeves2.Visibility = System.Windows.Visibility.Visible;
            mw.mageBrasTendus2.Visibility = System.Windows.Visibility.Hidden;
        }
        public override void PostureMageBrasTendus(MainWindow mw)
        {
            mw.mageStatique2.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasLeves2.Visibility = System.Windows.Visibility.Hidden;
            mw.mageBrasTendus2.Visibility = System.Windows.Visibility.Visible;
        }


        public override void RemiseAZeroElementPret(MainWindow mw)
        {
            base.RemiseAZeroElementPret(mw);
            mw.elementFeu2.Opacity = 0.4;
            mw.elementEau2.Opacity = 0.4;
            mw.elementTerre2.Opacity = 0.4;
        }


        public override void Attaquer(Joueur joueurAdverse, MainWindow mw)
        {
            if (typeCurrentElement == ElemType.Unknown)
                return;
            base.Attaquer(joueurAdverse, mw);
            ProjectileUserControl projectile = new ProjectileUserControl() { TypeProjectile = typeCurrentElement };
            projectile.SetValue(Canvas.RightProperty, 140.0);
            projectile.SetValue(Canvas.BottomProperty, 140.0);
            mw.canvasJeu.Children.Add(projectile);
            DeplacementProjectile(projectile, mw, joueurAdverse);
            RemiseAZeroElementPret(mw);
        }

        public override async Task AnimateProjectile(UIElement projectile, int milliseconds, MainWindow mw, Joueur joueurAdverse, ElemType elementProjectile)
        {
            TranslateTransform trs = new TranslateTransform();
            DoubleAnimation anim;
            anim = new DoubleAnimation(0, - mw.canvasJeu.ActualWidth + 280, TimeSpan.FromMilliseconds(milliseconds));

            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            projectile.RenderTransform = trs;
            await Task.Delay(milliseconds);

            if (mw.ElementsContrant[elementProjectile] != joueurAdverse.elementBouclierPret)
            {
                anim = new DoubleAnimation(- mw.canvasJeu.ActualWidth + 280, -mw.canvasJeu.ActualWidth + 230, TimeSpan.FromMilliseconds(400));
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
                    mw.coeur3j2.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    mw.coeur2j2.Visibility = Visibility.Hidden;
                    break;
                case 0:
                    mw.coeur1j2.Visibility = Visibility.Hidden;
                    MessageBox.Show("Le joueur 1 a gagné !  Relancez la partie.");
                    mw.RecommencerPartie();                                
                    break;
            }

        }


    }
}
