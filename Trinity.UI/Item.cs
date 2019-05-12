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

    class Item
    {
        Sprite sprite;
        RenderWindow window;
        Dictionary<string, Equipement> equip;
        List<Equipement> equipList;
        List<Sprite> itemSpriteList = new List<Sprite>();
        ItemDescription itemDescription;
        List<Equipement> equipementList = new List<Equipement>();
        Option_Info_UI option;
        Tower _context;

        public Item(Dictionary<string, Equipement> equipementDictionnary, RenderWindow newWindow)
        {
            equip = equipementDictionnary;
            window = newWindow;
        }

        public Item(List<Equipement> equipementList, RenderWindow newWindow)
        {
            equipList = equipementList;
            window = newWindow;
        }


        public void Draw(Sprite inventorySprite)
        {
            int x = 0;
            int y = 0;

            foreach (KeyValuePair<string, Equipement> item in equip)
            {
                sprite = new Sprite(new Texture(item.Value.Path));
                sprite.Position = new Vector2f(27f * (float)inventorySprite.Scale.X + x * 62f * (float)inventorySprite.Scale.X, 286f * (float)inventorySprite.Scale.Y);
                sprite.Scale = new Vector2f((float)inventorySprite.Scale.X, (float)inventorySprite.Scale.Y);

                equipementList.Add(item.Value);
                itemSpriteList.Add(sprite);
                window.Draw(sprite);

                float scaleX = (float)window.Size.X / 1700f;
                float scaleY = (float)window.Size.Y / 900f;
                int equipement = 0;


                foreach (Sprite sprite in itemSpriteList)
                {
                    if ((float)Mouse.GetPosition(window).X > sprite.Position.X * scaleX && (float)Mouse.GetPosition(window).X < sprite.Position.X * scaleX + 54f * scaleX
                         && (float)Mouse.GetPosition(window).Y > sprite.Position.Y * scaleY && (float)Mouse.GetPosition(window).Y < sprite.Position.Y * scaleY + 54f * scaleY)


                    if ((float)Mouse.GetPosition(window).X > sprite.Position.X  && (float)Mouse.GetPosition(window).X < sprite.Position.X  + 54f * scaleX
                        && (float)Mouse.GetPosition(window).Y > sprite.Position.Y  && (float)Mouse.GetPosition(window).Y < sprite.Position.Y  + 54f * scaleY)

                    {
                        itemDescription = new ItemDescription(equipementList[equipement], window);
                        itemDescription.Draw(window);
                    }
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        //option = new Option_Info_UI(summoner, window);
                    }
                    equipement++;
                }

                x++;
                if (x == 9)
                {
                    x = 0;
                    y++;
                }
                    
            }




        }
        
        public void Draw_Store(Sprite storeSprite)
        {
            int x = 0;
            int y = 0;

            for(int i = 0; i < equipList.Count; i++)
            {
                sprite = new Sprite(new Texture(equipList[i].Path));
                sprite.Position = new Vector2f(1131f * (float)storeSprite.Scale.X, 285f * (float)storeSprite.Scale.Y);
                sprite.Scale = new Vector2f((float)storeSprite.Scale.X, (float)storeSprite.Scale.Y);
                window.Draw(sprite);

                itemSpriteList.Add(sprite);

            }
        }
    }
}