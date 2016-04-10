using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public class BrasCroisesPosture : Posture
    {
        public override GestureType Type
        {
            get
            {
                return Gesture.GestureType.Action;
            }
        }

        internal protected override bool TestPosture(Skeleton s)
        {
            if (s.Joints[JointType.HandLeft].Position.X > s.Joints[JointType.HandRight].Position.X &&
                s.Joints[JointType.HandLeft].Position.Y > s.Joints[JointType.ElbowRight].Position.Y)
            {
                return true;
            }
            return false;
        }
    }
}
