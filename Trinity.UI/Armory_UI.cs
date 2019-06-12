using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Trinity.UI
{
    class Armory_UI
    {
        public float Xpos;
        public float Ypos;
        Sprite sprite;
        Texture texture;
        bool _draw;
        Tower _context;
        Item _item;
        Summoner _summoner;
        static Minion[] minionTab;

        public Armory_UI(string filename, Summoner summoner, RenderWindow window)
        {
            _summoner = summoner;
            texture = new Texture(filename);
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            _draw = false;
            minionTab[0] = _summoner.Inventory.Minion1;
            minionTab[1] = _summoner.Inventory.Minion2;
            minionTab[2] = _summoner.Inventory.Minion3;
            
        }
        public void Draw(RenderWindow window)
        {
            int i = 0;
            foreach (Minion minion in minionTab)
            {
                sprite.Position = new Vector2f (0 + i*200, 560);


                i++;
            }
            _draw = true;
            window.Draw(sprite);
        }

        public bool Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }
    }
}