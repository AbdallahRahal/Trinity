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
            RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(1700, 900), "Trinity");
            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;

            // Generation
            /* Map map = new Map(); */
            Player player = new Player();

            Clock clock = new Clock();

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(new Color(0, 0, 0))  ;

                float deltaTime = clock.Restart().AsSeconds();

                // Update
                player.Update(deltaTime);

                // Draw 
                /* map.Draw(window); */
                player.Draw(window);

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
