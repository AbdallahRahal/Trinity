using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity.UI
{
    class Animation
    {
        public int offsetTop;
        public int offsetLeft;
        public int numFrames;

        public Animation(int offsetTop, int offsetLeft, int numFrames)
        {
            this.offsetTop = offsetTop;
            this.offsetLeft = offsetLeft;
            this.numFrames = numFrames;

        }
    }
}
