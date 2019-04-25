using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

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
