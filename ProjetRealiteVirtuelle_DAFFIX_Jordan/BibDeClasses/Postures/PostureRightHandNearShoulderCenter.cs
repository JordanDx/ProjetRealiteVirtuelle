using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibDeClasses
{
    class PostureRightHandNearShoulderCenter : Posture
    {
        protected internal override bool TestPosture(Microsoft.Kinect.Skeleton s)
        {
            /*
            var handRight = s.Joints[Microsoft.Kinect.JointType.HandRight];
            var shoulderCenter = s.Joints[Microsoft.Kinect.JointType.ShoulderCenter];
            var shoulderLeft = s.Joints[Microsoft.Kinect.JointType.ShoulderLeft];
            var shoulderRight = s.Joints[Microsoft.Kinect.JointType.ShoulderRight];
            if (handRight.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked
                || shoulderCenter.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked
                || shoulderLeft.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked
                || shoulderRight.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked
                )
                return false;

            var handRightPosition = s.Joints[Microsoft.Kinect.JointType.HandRight].Position;
            return handRightPosition.Y > s.Joints[Microsoft.Kinect.JointType.ShoulderCenter].Position.Y
                    //&& handRightPosition.X > s.Joints[Microsoft.Kinect.JointType.ShoulderLeft].Position.X
                    && handRightPosition.X > s.Joints[Microsoft.Kinect.JointType.Head].Position.X;  */

            var handRight = s.Joints[Microsoft.Kinect.JointType.HandRight];
            var shoulderCenter = s.Joints[Microsoft.Kinect.JointType.ShoulderCenter];
            if (handRight.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked || shoulderCenter.TrackingState != Microsoft.Kinect.JointTrackingState.Tracked)
                return false;
            var handRightPosition = handRight.Position;
            var shoulderCenterPosition = shoulderCenter.Position;
            System.Windows.Media.Media3D.Vector3D vector = new System.Windows.Media.Media3D.Vector3D(handRightPosition.X - shoulderCenterPosition.X,
                                                                                                     handRightPosition.Y - shoulderCenterPosition.Y,
                                                                                                     handRightPosition.Z - shoulderCenterPosition.Z);
            return vector.Length < 0.3;
        }
    }
}
