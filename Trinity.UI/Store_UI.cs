using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Trinity.UI
{
    class Store_UI
    {
        public float Xpos;
        public float Ypos;
        Sprite sprite;
        Texture texture;
        bool _draw;
        Tower _context;
        Item _item;

        public Store_UI(string filename,Tower tower, RenderWindow window)
        {
            Xpos = 520;
            Ypos = 0;
            texture = new Texture(filename);
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            sprite.Position = new Vector2f(Xpos, Ypos);
            _draw = false;
            _context = tower;
        }

        public void Draw(RenderWindow window)
        {
            _draw = true;
            window.Draw(sprite);
            _item = new Item(_context.Store.Aviable_Equipement, window);
        }

        public bool Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }
    }
}
