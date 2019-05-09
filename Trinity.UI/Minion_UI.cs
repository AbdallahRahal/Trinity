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

    class Minion_UI
    {

        Sprite sprite;
        RenderWindow window;
        // MinionDescription minionDescription;
        Dictionary<string, Minion> minion;
        List<Sprite> minionSpriteList = new List<Sprite>();
        MinionDescription minionDescription;
        List<Minion> minionList = new List<Minion>();


        public Minion_UI(Dictionary<string, Minion> minionDictionnary, RenderWindow newWindow)
        {
            minion = minionDictionnary;
            window = newWindow;
        }

        public void Draw(Sprite inventorySprite)
        {
            int y = 0;
            foreach (KeyValuePair<string, Minion> item in minion)
            {

                sprite = new Sprite(new Texture(item.Value.Path));
                sprite.Position = new Vector2f(512f * inventorySprite.Scale.X, (y * 62f + 58f ) * inventorySprite.Scale.Y);  
                sprite.Scale = new Vector2f(inventorySprite.Scale.X, inventorySprite.Scale.Y);

                minionList.Add(item.Value);
                minionSpriteList.Add(sprite);
                window.Draw(sprite);



                float scaleX = (float)window.Size.X / 1700f;
                float scaleY = (float)window.Size.Y / 900f;
                int min = 0;

                foreach (Sprite sprite in minionSpriteList)
                {

                    if ((float)Mouse.GetPosition(window).X > sprite.Position.X && (float)Mouse.GetPosition(window).X < sprite.Position.X + 54f * scaleX
                        && (float)Mouse.GetPosition(window).Y > sprite.Position.Y && (float)Mouse.GetPosition(window).Y < sprite.Position.Y + 54f * scaleY)

                    {
                        minionDescription = new MinionDescription(minionList[min], window);
                        minionDescription.Draw(window);
                        

                    }

                    
                    min++;
                }

                y++;
            }

        }

        
    }
}
