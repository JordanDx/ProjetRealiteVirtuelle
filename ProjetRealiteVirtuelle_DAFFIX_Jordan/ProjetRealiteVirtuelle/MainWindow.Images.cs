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

        //Dictionnaire des éléments prêts ou non affichés du joueur 1
       Dictionary<ElemType, UIElement> imagesElements = new Dictionary<ElemType, UIElement>();
       
        public Dictionary<ElemType, UIElement> ImagesElements
       {
           get
           {
               return imagesElements;
           }
       }

        private void InitDictionaryImagesElements()
        {
            imagesElements.Add(ElemType.Feu, elementFeu);
            imagesElements.Add(ElemType.Eau, elementEau);
            imagesElements.Add(ElemType.Terre, elementTerre);
        }

        //Dictionnaire des boucliers du joueur 1
        Dictionary<ElemType, UIElement> imagesBoucliers = new Dictionary<ElemType, UIElement>();

        public Dictionary<ElemType, UIElement> ImagesBoucliers
        {
            get
            {
                return imagesBoucliers;
            }
        }

        private void InitDictionaryImagesBoucliers()
        {
            imagesBoucliers.Add(ElemType.Feu, bouclierFeu);
            imagesBoucliers.Add(ElemType.Eau, bouclierEau);
            imagesBoucliers.Add(ElemType.Terre, bouclierTerre);
        }



        
        //Dictionnaire des éléments prêts ou non affichés du joueur 2
        Dictionary<ElemType, UIElement> imagesElementsJoueur2 = new Dictionary<ElemType, UIElement>();

        public Dictionary<ElemType, UIElement> ImagesElementsJoueur2
        {
            get
            {
                return imagesElementsJoueur2;
            }
        }

        private void InitDictionaryImagesElementsJoueur2()
        {
            imagesElementsJoueur2.Add(ElemType.Feu, elementFeu2);
            imagesElementsJoueur2.Add(ElemType.Eau, elementEau2);
            imagesElementsJoueur2.Add(ElemType.Terre, elementTerre2);
        }


        //Dictionnaire des boucliers du joueur 2
        Dictionary<ElemType, UIElement> imagesBoucliersJoueur2 = new Dictionary<ElemType, UIElement>();

        public Dictionary<ElemType, UIElement> ImagesBoucliersJoueur2
        {
            get
            {
                return imagesBoucliersJoueur2;
            }
        }

        private void InitDictionaryImagesBoucliersJoueur2()
        {
            imagesBoucliersJoueur2.Add(ElemType.Feu, bouclierFeu2);
            imagesBoucliersJoueur2.Add(ElemType.Eau, bouclierEau2);
            imagesBoucliersJoueur2.Add(ElemType.Terre, bouclierTerre2);
        }
    }
}
