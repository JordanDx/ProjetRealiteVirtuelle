using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDeClasses
{
    class PostureRightHandNearLeftHip : Posture
    {
        internal protected override bool TestPosture(Microsoft.Kinect.Skeleton s)
        {
            var handRight = s.Joints[Microsoft.Kinect.JointType.HandRight];
            var hipLeft = s.Joints[Microsoft.Kinect.JointType.HipLeft];
            if (handRight.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked || hipLeft.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked)
                return false;
            var handRightPosition = handRight.Position;
            var hipLeftPosition = hipLeft.Position;
            System.Windows.Media.Media3D.Vector3D vector = new System.Windows.Media.Media3D.Vector3D(handRightPosition.X - hipLeftPosition.X,
                                                                                                     handRightPosition.Y - hipLeftPosition.Y,
                                                                                                     handRightPosition.Z - hipLeftPosition.Z);
            return vector.Length < 0.2;
        }
    }
}
