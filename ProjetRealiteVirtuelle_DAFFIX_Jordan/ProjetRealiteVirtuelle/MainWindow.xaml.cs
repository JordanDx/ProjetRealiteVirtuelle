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

    

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        private CustomEngine customEngine;



        private Joueur joueur1 = new JoueurGauche();
        private Joueur joueur2 = new JoueurDroit();

        private MediaPlayer mediaPlayerMusique = new MediaPlayer();  

        MediaPlayer mediaPlayerSons = new MediaPlayer();
        public MediaPlayer MediaPlayerSons
        {
            get
            {
                return mediaPlayerSons;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            InitDictionaryImagesElements();
            InitDictionaryImagesBoucliers();
            InitDictionaryImagesElementsJoueur2();
            InitDictionaryImagesBoucliersJoueur2();
            customEngine = new CustomEngine();
            
            
            foreach (Gesture g in customEngine.collectionGestes) 
            {
                g.GestureRecognized += this.OnGestureRecognized;
            }
             
            mediaPlayerMusique.Open(new Uri(@"../../Sons/Musique.mp3", UriKind.Relative));
            mediaPlayerMusique.Play();
            
        }

        /// <summary>
        /// Execute startup tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            // Look through all sensors and start the first connected one.
            // This requires that a Kinect is connected at the time of app startup.
            // To make your app robust against plug/unplug, 
            // it is recommended to use KinectSensorChooser provided in Microsoft.Kinect.Toolkit (See components in Toolkit Browser).
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                // Turn on the skeleton stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();

                // Add an event handler to be called whenever there is new color frame data
                this.sensor.SkeletonFrameReady += this.SensorSkeletonFrameReady;

                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                this.statusBarTextSquelette1.Text = "Sensor is null.";
            }
        }

        /// <summary>
        /// Execute shutdown tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
        }
        
        /// <summary>
        /// Event handler for Kinect sensor's SkeletonFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            
            Skeleton[] skeletons = new Skeleton[0];

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);

                    Skeleton firstSkel = skeletons.Where(skel => skel.TrackingState == SkeletonTrackingState.Tracked)
                                                  .OrderBy(skel => skel.Position.Z)
                                                  .FirstOrDefault();
                    if (firstSkel == null)
                    {
                        statusBarTextSquelette1.Text = "aucun squelette détecté";
                        return;
                    }
                    //ce foreach sera utilisé pour que les actions des deux squelettes soient reconnues.
                    //foreach (Skeleton s in skeletons.Where(skel => skel.TrackingState == SkeletonTrackingState.Tracked)) 
                    //{
                    customEngine.TestGestes(firstSkel);
                    statusBarTextSquelette1.Text = "squelette détecté";
                    //}
                   
                }
                else
                {
                    statusBarTextSquelette1.Text = "aucun squelette détecté";
                }
            }
        }


        /*
        public void OnGestureRecognized(object sender, GestureRecognizedEventArgs args)
        {         
            switch (args.typeGeste)
            {
                case Gesture.GestureType.Selection:
                    typeCurrentElement = sélections[args.nomGeste];
                    ElementPret(typeCurrentElement);
                    break;
                case Gesture.GestureType.Action:
                    if (typeCurrentElement == ElemType.Unknown) break;
                    actions[args.nomGeste](typeCurrentElement, this);
                    break;
            }    
        }
        */


        // ! : Seuls les gestes du joueur 1 sont reconnus, le code est à changer. On peut utiliser les boutons en attendant pour simuler les gestes du joueur 2.
        public void OnGestureRecognized(object sender, GestureRecognizedEventArgs args)
        {

            switch (args.typeGeste)
            {
                case Gesture.GestureType.Selection:
                    joueur1.ElementPret(sélections[args.nomGeste], this);
                    break;
                case Gesture.GestureType.Action:
                    if (joueur1.typeCurrentElement == ElemType.Unknown) break;
                    actions[args.nomGeste](joueur1, joueur2, this);
                    break;
            }
        }


        public void RecommencerPartie()
        {
            joueur1.vie = 3;
            joueur2.vie = 3;
            coeur1j1.Visibility = System.Windows.Visibility.Visible;
            coeur2j1.Visibility = System.Windows.Visibility.Visible;
            coeur3j1.Visibility = System.Windows.Visibility.Visible;
            coeur1j2.Visibility = System.Windows.Visibility.Visible;
            coeur2j2.Visibility = System.Windows.Visibility.Visible;
            coeur3j2.Visibility = System.Windows.Visibility.Visible;
            joueur1.PostureMageStatique(this);
            joueur2.PostureMageStatique(this);
            joueur1.RemiseAZeroBouclier(this);
            joueur1.RemiseAZeroElementPret(this);
            joueur2.RemiseAZeroElementPret(this);
           
        }



    }
}
