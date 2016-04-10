using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public class CustomEngine
    {

        public String derniereGestureReconnue
        {
            get;
            private set;
        }

        public List<Gesture> collectionGestes = new List<Gesture>();

        public CustomEngine() {
            collectionGestes.Add(new LeftHandUpPosture());
            collectionGestes.Add(new BrasCroisesPosture());
            collectionGestes.Add(new BrasTendusPosture());
            collectionGestes.Add(new GestureTerre());
            collectionGestes.Add(new BrasTendusADroitePosture());
            collectionGestes.Add(new BrasTendusAGauchePosture());

            abonnement();
        }

        public void TestGestes(Skeleton s){
            foreach (Gesture g in collectionGestes) {
                g.TestGesture(s);
            }
        }

        public void OnGestureRecognized(object sender, GestureRecognizedEventArgs args)
        {
            derniereGestureReconnue = args.nomGeste;
        }

        public void abonnement() {
            foreach (Gesture g in collectionGestes)
            {
                g.GestureRecognized += this.OnGestureRecognized;
            }
        }

        
    }
}
