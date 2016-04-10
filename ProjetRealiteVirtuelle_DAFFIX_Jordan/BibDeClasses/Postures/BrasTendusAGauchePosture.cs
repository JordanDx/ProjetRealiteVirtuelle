using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public class BrasTendusAGauchePosture : Posture
    {

        public override GestureType Type
        {
            get
            {
                return Gesture.GestureType.Unknown; //Pourra servir pour un élément futur
            }
        }

        internal protected override bool TestPosture(Skeleton s)
        {
            if (s.Joints[JointType.HandLeft].Position.X < s.Joints[JointType.ShoulderLeft].Position.X &&
                s.Joints[JointType.HandRight].Position.X < s.Joints[JointType.ShoulderLeft].Position.X &&
                s.Joints[JointType.HandLeft].Position.X < s.Joints[JointType.ElbowLeft].Position.X)
            {
                return true;
            }
            return false;
        }

    }
}
