using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Trinity.UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            SFML.GraphicsNative.Load();
            SFML.AudioNative.Load();
            Trinity trinity = new Trinity();
            trinity.Run();
        }
    }
}
