using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public class BrasTendusADroitePosture : Posture
    {
        public override GestureType Type
        {
            get
            {
                return Gesture.GestureType.Selection;
            }
        }

        internal protected override bool TestPosture(Skeleton s)
        {
            if (s.Joints[JointType.HandLeft].Position.X > s.Joints[JointType.ShoulderRight].Position.X &&
                s.Joints[JointType.HandRight].Position.X > s.Joints[JointType.ShoulderRight].Position.X &&
                s.Joints[JointType.HandRight].Position.X > s.Joints[JointType.ElbowRight].Position.X)
            {
                return true;
            }
            return false;
        }

    }
}
