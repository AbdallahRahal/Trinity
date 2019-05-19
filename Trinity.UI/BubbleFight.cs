using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;
using System.Linq;

namespace Trinity.UI
{
    class BubbleFight
    {
        RenderWindow _window;
        Tower _context;
        Dictionary<IDrawable,int> bubble = new Dictionary<IDrawable, int>();
        Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));


        public BubbleFight(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;
            
        }

        public void Change_type(int x, Sprite minionPos)
        {
            if(x == -1) // l'attaque a raté
            {
                Sprite sprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/rate.png")));
                sprite.Position = minionPos.Position;
                bubble.Add(sprite,0);
            }
            else if (x >= 0) // l'attaque a réussi
            {
                Text text = new Text("", font, 35);
                text.DisplayedString = "-" + x;
                text.Position = minionPos.Position;
                text.FillColor = new Color(255, 255, 255);
                bubble.Add(text, 0);
            }
        }



        public void Draw()
        {
            List<IDrawable> bubbleList = bubble.Keys.ToList();
            foreach (IDrawable bub in bubbleList)
            {

                if (bubble[bub] > 50)
                {
                    bubble.Remove(bub);
                }
                else
                {
                   bubble[bub]++;


                    if (bub is Text)
                    {
                        Text text = (Text)bub;
                        text.Position = new Vector2f(text.Position.X, text.Position.Y - 1);
                        
                    }
                    if (bub is Sprite)
                    {
                        Sprite sprite = (Sprite)bub;
                        sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y - 1);
                        
                    }
                    _window.Draw(bub);
                }

            }







        }

    }

}
