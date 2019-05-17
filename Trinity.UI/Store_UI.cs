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
    class Store_UI
    {
        public float Xpos;
        public float Ypos;
        Sprite sprite;
        Texture texture;
        bool _draw;
        Tower _context;
        Item _item;
        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Gold", font, 15);


        public Store_UI(string filename,Tower tower, RenderWindow window)
        {
            Xpos = window.Size.X - (window.Size.X - 1245 + 600) * window.Size.X / 1700f;
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
            text.DisplayedString = "Money Argent Pesos Oseille Dol's : " + _context.Summoner.Money.ToString("### ### ###");
            text.Position = new Vector2f(672f * window.Size.X / 1700f, 256f * window.Size.Y / 900f);
            text.FillColor = new Color(0, 0, 0);
            window.Draw(sprite);
            window.Draw(text);
            _item = new Item(_context.Store.available_Equipement, window, _context);
            _item.Draw_Store(sprite);
        }

        public bool Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }
        public Item item
        {
            get { return _item; }
        }
    }
}
