using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    class GestureTerre : GesteDynamique
    {
        PostureRightHandNearLeftHip initPosture = new PostureRightHandNearLeftHip();
        PostureRightHandNearShoulderCenter endingPosture = new PostureRightHandNearShoulderCenter();

        float positionMainDroiteX;
        float positionMainDroiteY;
        
        public override GestureType Type
        {
            get
            {
                return Gesture.GestureType.Selection;
            }
        }
        
        protected override bool TestConditionsInit(Microsoft.Kinect.Skeleton s)
        {
            positionMainDroiteX = s.Joints[JointType.HandRight].Position.X;
            positionMainDroiteY = s.Joints[JointType.HandRight].Position.Y;
            return initPosture.TestPosture(s);
        }

        protected override bool TestConditionsFin(Microsoft.Kinect.Skeleton s)
        {
            return endingPosture.TestPosture(s);
        }

        protected override bool TestDynamique(Microsoft.Kinect.Skeleton s)
        {
            /*
            if (CurrentNbOfFrames % 4 != 0) return true;

            nouvellePositionMainDroiteX = s.Joints[JointType.HandRight].Position.X;
            nouvellePositionMainDroiteY = s.Joints[JointType.HandRight].Position.Y;

            if(nouvellePositionMainDroiteX > positionMainDroiteX &&
                nouvellePositionMainDroiteY > positionMainDroiteY)
            {
                positionMainDroiteX = nouvellePositionMainDroiteX;
                positionMainDroiteY = nouvellePositionMainDroiteY;
                return true;
            }

            return false;
             */

            return true;
             
        }

        protected override bool TestPosture(Microsoft.Kinect.Skeleton s)
        {
            if (s.Joints[JointType.HandRight].Position.Y < s.Joints[JointType.Head].Position.Y &&
               s.Joints[JointType.HandRight].Position.X < s.Joints[JointType.ShoulderRight].Position.X)
            {
                return true;
            }
            return false;
        }
    }
}
