using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Kinect;

namespace BibDeClasses
{
    public abstract class Gesture
    {
        
        public enum GestureType : byte
        {
            Unknown = 0,
            Action = 1,
            Selection = 2
        }

        public virtual String nom
        {
            get
            {
                return GetType().Name;
            }
        }

        public virtual GestureType Type
        {
            get
            {
                return GestureType.Unknown;
            }
        }


        public event EventHandler<GestureRecognizedEventArgs> GestureRecognized;

        protected virtual void OnGestureRecognized() {
            if (GestureRecognized != null) {
                GestureRecognized(this, new GestureRecognizedEventArgs(nom, Type));
            }
        }

        public abstract void TestGesture(Skeleton s);
    }
}
