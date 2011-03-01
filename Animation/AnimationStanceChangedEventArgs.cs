using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XGT.Animation
{
    public class AnimationStanceChangedEventArgs : EventArgs
    {
        public int oldStance;
        public int newStance;

        public AnimationStanceChangedEventArgs(int lOldStance, int lNewStance)
        {
            oldStance = lOldStance;
            newStance = lNewStance;
        }
    }
}
