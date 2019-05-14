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
   
    class Inventory_UI
    {
        Sprite sprite;
        Texture texture;
        bool _draw;
        Summoner _summoner ;
        Item item;
        Minion_UI minion;
        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Gold", font, 15);

        public Inventory_UI(string filename, Summoner summoner, RenderWindow window)
        {
           
            texture = new Texture(filename);
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            _draw = false;
            _summoner = summoner;
            
        }
        
        public void Draw(RenderWindow window)
        {
            text.DisplayedString = "Money Argent Pesos Oseille Dol's : " +_summoner.Money.ToString("### ### ###") ;
            text.Position = new Vector2f(27f * window.Size.X / 1700f, 256f * window.Size.Y / 900f);
            text.FillColor = new Color(0, 0, 0);
            _summoner.Inventory.Update();
            _draw = true;
            window.Draw(sprite);
            window.Draw(text);

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