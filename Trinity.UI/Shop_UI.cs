using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Trinity.UI
{
    class Shop_UI
    {
        Sprite sprite;
        Texture texture;
        bool _draw;
        Item item;

        public Shop_UI(string filename, Summoner summoner, RenderWindow window)
        {

            texture = new Texture(filename);
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            _draw = false;

        }
        public void Draw(RenderWindow window)
        {
            _draw = true;
            window.Draw(sprite);
        }
    }
}
