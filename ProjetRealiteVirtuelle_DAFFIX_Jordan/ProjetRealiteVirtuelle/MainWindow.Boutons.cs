using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Kinect;
using System.IO;
using BibDeClasses;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ProjetRealiteVirtuelle
{
    public partial class MainWindow
    {

        //Boutons du joueur 1
                
        private void ClicElementFeuPret(object sender, RoutedEventArgs e)
        { 
            joueur1.ElementPret(ElemType.Feu, this);
        }
        
        
        private void ClicElementEauPret(object sender, RoutedEventArgs e)
           { 
            joueur1.ElementPret(ElemType.Eau, this);
        }

        private void ClicElementTerrePret(object sender, RoutedEventArgs e)
           { 
            joueur1.ElementPret(ElemType.Terre, this);
        }


        
        private void ClicAttaquer(object sender, RoutedEventArgs e)
        {

            joueur1.Attaquer(joueur2, this);
        }
        

        

        private void ClicDefendre(object sender, RoutedEventArgs e)
        {
            joueur1.AfficherBouclier(this);
        }


        


        //Boutons du joueur 2

        private void ClicElementFeuPretJoueur2(object sender, RoutedEventArgs e)
        { 
            joueur2.ElementPret(ElemType.Feu, this);
        }
        
        private void ClicElementEauPretJoueur2(object sender, RoutedEventArgs e)
        {
            joueur2.ElementPret(ElemType.Eau, this);
        }

        private void ClicElementTerrePretJoueur2(object sender, RoutedEventArgs e)
        {
            joueur2.ElementPret(ElemType.Terre, this);
        }

        private void ClicAttaquerJoueur2(object sender, RoutedEventArgs e)
        {
            joueur2.Attaquer(joueur1, this);
        }

        private void ClicDefendreJoueur2(object sender, RoutedEventArgs e)
        {
            joueur2.AfficherBouclier(this);
        }
         
    }
}
