using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SFML.System;

namespace Trinity.UI
{
    class Menu
    {
        static Font _font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        RenderWindow _window;

        public Menu(RenderWindow Window)
        {
            _window = Window;
            Window.Draw(CreateShape(1700, 900, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/MenuMain.jpg"),0,0));
        }

        internal Shape CreateShape(Vector2f Size, string Link, int PosX, int PosY)
        {
            RectangleShape button = new RectangleShape()
            {
                Size = Size,
                Texture = new Texture(Link),
                Position = new Vector2f(PosX, PosY)
            };
            return button;
        }

        internal Shape CreateShape(int X, int Y, string Link, int PosX, int PosY)
        {
            RectangleShape button = new RectangleShape()
            {
                Size = new Vector2f(X, Y),
                Position = new Vector2f(PosX, PosY),
                Texture = new Texture(Link)
            };
            return button;
        }

        public Shape[] Menu_Display()
        {
            Vector2f Size = new Vector2f(250, 72);
            Shape[] buttons = new RectangleShape[4];

            Shape MenuBackground = CreateShape(1700, 900, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/MenuMain.jpg"),0,0);
            _window.Draw(MenuBackground);

            _window.Draw(buttons[0] = CreateShape(Size, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bouton_new_game.PNG"), 300, 300));
            _window.Draw(buttons[1] = CreateShape(Size, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bouton_new_History.png"), 300, 400));
            _window.Draw(buttons[2] = CreateShape(Size, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bouton_new_credits.png"), 300, 500));
            _window.Draw(buttons[3] = CreateShape(Size, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bouton_quit_game.png"), 300, 600));

            return buttons;
        }

        public Shape History()
        {
            Vector2f Size = new Vector2f(150, 50);
            Shape button = new RectangleShape();

            Shape BackHome = CreateShape(1700, 900, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/history.png"),0,0);
            _window.Draw(BackHome);

            _window.Draw(button = CreateShape(Size, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bouton_back_home.png"), 246, 594));

            return button;
        }

    }

}
