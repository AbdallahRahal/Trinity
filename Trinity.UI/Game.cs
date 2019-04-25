using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.IO;
using SFML.Window;

namespace Trinity.UI
{
    class Game
    {
        public void Start()
        {
            RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Trinity");
            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;

            Map map = new Map();

            while (window.IsOpen)
            {
                window.DispatchEvents();

                //ndow.Clear(new Color(43, 100, 0, 0));
                map.Draw(window);

                window.Display();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
