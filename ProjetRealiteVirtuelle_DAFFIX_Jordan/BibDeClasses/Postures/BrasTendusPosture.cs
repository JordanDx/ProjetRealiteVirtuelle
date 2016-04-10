using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    class BrasTendusPosture : Posture
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
            if (s.Joints[JointType.HandLeft].Position.X < s.Joints[JointType.Head].Position.X &&
                s.Joints[JointType.HandRight].Position.X > s.Joints[JointType.Head].Position.X &&
                s.Joints[JointType.HandLeft].Position.Y < s.Joints[JointType.Head].Position.Y &&
                s.Joints[JointType.HandRight].Position.Y < s.Joints[JointType.Head].Position.Y &&
                (s.Joints[JointType.ShoulderLeft].Position.Z - s.Joints[JointType.HandLeft].Position.Z) > 0.3 &&
                (s.Joints[JointType.ShoulderRight].Position.Z - s.Joints[JointType.HandRight].Position.Z) > 0.3
                )
            {
                return true;
            }
            return false;
        }
    }
}
