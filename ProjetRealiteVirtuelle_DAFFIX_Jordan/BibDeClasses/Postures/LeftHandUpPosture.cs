using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public class LeftHandUpPosture : Posture
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
            if (s.Joints[JointType.HandLeft].Position.Y > s.Joints[JointType.Head].Position.Y)
            {
                return true;
            }
            return false;
        }

    }
}
