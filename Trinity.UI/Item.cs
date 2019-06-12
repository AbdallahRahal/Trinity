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
        ItemDescription itemDescription;
        List<Sprite> itemSpriteListShop = new List<Sprite>();
        List<Equipement> equipementListShop = new List<Equipement>();
        List<Sprite> itemSpriteList = new List<Sprite>();
        List<Equipement> equipementList = new List<Equipement>();
        Tower _context;


        public Item(Dictionary<string, Equipement> equipementDictionnary, RenderWindow newWindow) // inventaire
        {
            equip = equipementDictionnary;
            window = newWindow;

        }

        public Item(List<Equipement> equipementList, RenderWindow newWindow, Tower context ) //shop
        {
            equipList = equipementList;
            window = newWindow;
            _context = context;

        }

        /*public Item(Dictionary<string, Equipement> equipementDictionnary, RenderWindow newWindow) // armory
        {
            equip = equipementDictionnary;
            window = newWindow;
        }*/


        public void Draw(Sprite inventorySprite)
        {
            int x = 0;
            int y = 0;
            
            foreach (KeyValuePair<string, Equipement> item in equip)
            {
                sprite = new Sprite(new Texture(item.Value.Path));
                sprite.Position = new Vector2f(27f * (float)inventorySprite.Scale.X + x * 62f * (float)inventorySprite.Scale.X,(286f + y * 62f) * (float)inventorySprite.Scale.Y);
                sprite.Scale = new Vector2f((float)inventorySprite.Scale.X, (float)inventorySprite.Scale.Y);
                equipementList.Add(item.Value);
                itemSpriteList.Add(sprite);
                window.Draw(sprite);

                int equipement = 0;


                foreach (Sprite sprite in itemSpriteList)
                {
                    if ((float)Mouse.GetPosition(window).X > sprite.Position.X && (float)Mouse.GetPosition(window).X < sprite.Position.X + 54f && 
                        (float)Mouse.GetPosition(window).Y > sprite.Position.Y && (float)Mouse.GetPosition(window).Y < sprite.Position.Y + 54f)

                    {

                        itemDescription = new ItemDescription(equipementList[equipement], window);
                        itemDescription.Draw(window);
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

            for (int i = 0; i < equipList.Count; i++)
            {
                sprite = new Sprite(new Texture(equipList[i].Path));
                sprite.Position = new Vector2f((storeSprite.Position.X + 27f + i * 62f), 285f);


                equipementListShop.Add(equipList[i]);
                itemSpriteListShop.Add(sprite);
                window.Draw(sprite);


                int compte = 0;
                foreach (Sprite sprite in itemSpriteListShop)
                {
                    if (Mouse.GetPosition(window).X > sprite.Position.X && Mouse.GetPosition(window).X < sprite.Position.X + 54f
                     && Mouse.GetPosition(window).Y > sprite.Position.Y && Mouse.GetPosition(window).Y < sprite.Position.Y + 54f)
                    {
                        itemDescription = new ItemDescription(equipementListShop[compte], window);
                        itemDescription.Draw(window);
                    }

                    compte++;   
                }
            }
        }

        
    }
}