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

        public Inventory_UI(string filename, Summoner summoner)
        {
           
            texture = new Texture(filename);
            sprite = new Sprite(texture);
            _draw = false;
            _summoner = summoner;

        }
        
        public void Update()
        {
           
        }
        public void Draw(RenderWindow window)
        {
            int x = 0;
            int y = 0;
            _draw = true;
            window.Draw(sprite);
            
            foreach (KeyValuePair<string, Equipement> equip in _summoner.Inventory.Equipement) {
             
                Sprite spriteEquip = new Sprite(new Texture(equip.Value.Path));
                spriteEquip.Position = new Vector2f(27 + x*62, 286);
                window.Draw(spriteEquip);
                Console.WriteLine("X = {0}, Y = {1} et le sprite fait de {2}  et la fentre max est  {3}", Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y, spriteEquip.GetLocalBounds()
, window.Size );

                if (Mouse.GetPosition().X > spriteEquip.Position.X &&
                       Mouse.GetPosition().X < spriteEquip.Position.X + spriteEquip.Texture.Size.X &&
                       Mouse.GetPosition().Y < spriteEquip.Position.Y &&
                       Mouse.GetPosition().Y > spriteEquip.Position.Y + spriteEquip.Texture.Size.Y
                       )
                    {
                        Drawed = !Drawed;
                    }

                






                x++;
                if (x == 9)
                {
                    x = 0;
                    y++;
                }
            }
        }
        public bool  Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }

    }
}
