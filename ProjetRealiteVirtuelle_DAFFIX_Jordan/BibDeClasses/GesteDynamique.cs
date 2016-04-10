using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public abstract class GesteDynamique : Gesture
    {
        public bool isMoving
        {
            get;
            private set;
        }

        public int CurrentNbOfFrames
        {
            get;
            private set;
        }

        public virtual int MaxNbOfFrames
        {
            get
            {
                return 30; //30 fps => une seconde
            }
        }

        public override void TestGesture(Skeleton s)
        {
            if (!isMoving) 
            {
                if (TestConditionsInit(s))
                {
                    isMoving = true;
                    CurrentNbOfFrames = 0;
                }
                return;
            }
            if (TestConditionsFin(s))
            {
                isMoving = false;
                OnGestureRecognized();
                return;
            }
            if (!TestPosture(s) || !TestDynamique(s))
            {
                isMoving = false;
                return;
            }
            CurrentNbOfFrames++;
            if (CurrentNbOfFrames > MaxNbOfFrames)
            {
                isMoving = false;
            }
        }


        protected abstract bool TestConditionsInit(Skeleton s);

        protected abstract bool TestConditionsFin(Skeleton s);

        protected abstract bool TestDynamique(Skeleton s);

        protected abstract bool TestPosture(Skeleton s);
    }
}
