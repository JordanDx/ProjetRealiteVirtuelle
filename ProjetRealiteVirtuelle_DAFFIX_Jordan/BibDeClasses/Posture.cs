using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public abstract class Posture : Gesture
    {
        public override void TestGesture(Skeleton s) { 
            if (TestPosture(s))
            {
                OnGestureRecognized();
            }
        }

        internal protected abstract bool TestPosture(Skeleton s);
    }
}
