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

            // Generation
            /* Map map = new Map(); */
            Animated_Character player = new Animated_Character("C:/dev/Trinity/Trinity.UI/Sprites/Sprite_Character.png", 200);
            player.CurrentState = CharacterState.MovingRight;

            Clock clock = new Clock();

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(new Color(43, 100, 0, 0));

                float deltaTime = clock.Restart().AsSeconds();

                if(Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
                {
                    player.CurrentState = CharacterState.MovingRight;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Z) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
                {
                    player.CurrentState = CharacterState.MovingUp;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Q) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
                {
                    player.CurrentState = CharacterState.MovingLeft;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down))
                {
                    player.CurrentState = CharacterState.MovingDown;
                }

                // Player
                player.Update(deltaTime);

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
