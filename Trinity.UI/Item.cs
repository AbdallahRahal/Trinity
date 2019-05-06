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
        List<Sprite> itemSpriteList = new List<Sprite>();
        ItemDescription itemDescription;
        List<Equipement> equipementList = new List<Equipement>();
        public Item(Dictionary<string, Equipement> equipementDictionnary, RenderWindow newWindow)
        {
            equip = equipementDictionnary;
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
        
     
    }
    }
