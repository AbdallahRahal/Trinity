using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;

namespace Trinity.UI
{

    class MinionDescription
    {
        static Minion minion;
        static Sprite sprite;
        static Texture texture;
        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Test description objet", font, 12);

        public MinionDescription(Minion _minion, RenderWindow window)
        {
            minion = _minion;

            texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/MinionDescription.png"));
            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(Mouse.GetPosition(window).X, (Mouse.GetPosition(window).Y));

        }

        public void Draw(RenderWindow window)
        {
            int x = 1;
            
            window.Draw(sprite);


            foreach (string item in minion.Stats())
            { 

                text.DisplayedString = item;
                text.Position = new Vector2f(Mouse.GetPosition(window).X + 4f, (Mouse.GetPosition(window).Y) + (x * (2f + (float)text.CharacterSize)) * (float)window.Size.Y / 900f);
                text.FillColor = new Color(0, 0, 0);
                if (item.StartsWith(" "))
                {
                    text.FillColor = new Color(200, 0, 0);
                    text.DisplayedString = item;
                }
                window.Draw(text);
                x++;
            }
        }
    }
}
