using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System.IO;
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
        static Minion[] minionTab = new Minion[3];
        Sprite iconSprite;
        Sprite hatSprite;
        Sprite breastplateSprite;
        Sprite legSprite;
        Sprite bootsSprite;
        Sprite carreSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/carreSprite.png")));
        Sprite weaponSprite;
        Sprite gemSprite;

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
                sprite.Position = new Vector2f(0 + i * 200, 560);
                window.Draw(sprite);
                iconSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Path)));
                iconSprite.Position = new Vector2f(108 + i * 200, 605);
                if (minion.Armories.Hat != null)
                {
                    hatSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Armories.Hat.Path)));
                    hatSprite.Position = new Vector2f(17 + i * 200, 578);
                    carreSprite.Position = hatSprite.Position;
                    window.Draw(carreSprite);
                    window.Draw(hatSprite);
                }
                if (minion.Armories.Breastplate != null)
                {
                    breastplateSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Armories.Breastplate.Path)));
                    breastplateSprite.Position = new Vector2f(17 + i * 200, 638);
                    carreSprite.Position = breastplateSprite.Position;
                    window.Draw(carreSprite);
                    window.Draw(breastplateSprite);
                }

                if (minion.Armories.Leg != null)
                {
                    legSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Armories.Leg.Path)));
                    legSprite.Position = new Vector2f(17 + i * 200, 698);
                    carreSprite.Position = legSprite.Position;
                    window.Draw(carreSprite);
                    window.Draw(legSprite);
                }
                if (minion.Armories.Boots != null)
                {
                    bootsSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Armories.Boots.Path)));
                    bootsSprite.Position = new Vector2f(17 + i * 200, 758);
                    carreSprite.Position = bootsSprite.Position;
                    window.Draw(carreSprite);
                    window.Draw(bootsSprite);
                }
                if (minion.Armories.Weapon != null)
                {
                    weaponSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Armories.Weapon.Path)));
                    weaponSprite.Position = new Vector2f(106 + i * 200, 667);
                    carreSprite.Position = weaponSprite.Position;
                    window.Draw(carreSprite);
                    window.Draw(weaponSprite);
                }
                if (minion.Armories.Gem1 != null)
                {
                    gemSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), minion.Armories.Gem1.Path)));
                    gemSprite.Position = new Vector2f(106 + i * 200, 729);
                    carreSprite.Position = gemSprite.Position;
                    window.Draw(carreSprite);
                    window.Draw(gemSprite);
                }
                i++;
                window.Draw(iconSprite);
            }
                _draw = true;
        }

        public bool Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }
    }
}