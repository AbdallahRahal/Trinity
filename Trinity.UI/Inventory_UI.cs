using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Trinity.UI
{
   
    class Inventory_UI
    {
        Sprite sprite;
        Texture texture;
        bool _draw;
        Summoner _summoner ;
        Item item;
        Minion_UI minion;

        public Inventory_UI(string filename, Summoner summoner ,RenderWindow window)
        {
           
            texture = new Texture(filename);
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            _draw = false;
            _summoner = summoner;
            
        }
        
        public void Draw(RenderWindow window)
        {

            _summoner.Inventory.Update();

            _draw = true;
            window.Draw(sprite);

            item = new Item(_summoner.Inventory.Equipement, window);
            item.Draw(sprite);


            minion = new Minion_UI(_summoner.Inventory.minionItem, window);
            minion.Draw(sprite);
        }
        
        public bool  Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }

    }
}