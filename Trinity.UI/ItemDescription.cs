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

    class ItemDescription
    {
        static Equipement equip;
        static Sprite sprite;
        static Texture texture;
        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Test description objet", font, 12);

        public ItemDescription(Equipement equipement, RenderWindow window)
        {
            equip = equipement;

            texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ItemDescription.png"));
            sprite = new Sprite(texture);
            sprite.Position = new Vector2f(Mouse.GetPosition(window).X, (Mouse.GetPosition(window).Y)-138f* (float)window.Size.Y / 900f);

        }


        public void  Draw(RenderWindow window)
        {
            int x = 1;
           
            
            window.Draw(sprite);


            foreach (KeyValuePair<string, string> item in equip.Stats())
            {
                text.DisplayedString = item.Key+item.Value;
                text.Position = new Vector2f(Mouse.GetPosition(window).X + 4f, (Mouse.GetPosition(window).Y) - (138f - x * (2f+(float)text.CharacterSize)) * (float)window.Size.Y / 900f);
                text.FillColor = new Color(0, 0, 0);
                if (item.Key == "Type : ") {
                    text.FillColor = new Color(200, 0, 0);
                    text.DisplayedString = item.Value;
                }
                window.Draw(text);
                x ++;
            }
        }
    }
}
