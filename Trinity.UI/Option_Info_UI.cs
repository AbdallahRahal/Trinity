using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;
using System.Linq;


//classe d'affichage du sprite d'option lors d'un click sur un item  pour l'equiper et deséquiper
namespace Trinity.UI
{
    class Option_Info_UI
    {
        Window _window;
        Tower _context;
        Texture texture;
        Sprite sprite;
        Equipement _equipement;
        bool _drawed;
        Equipement equip;  // l'equipement en question

        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Texte option equipement", font, 15);


        public Option_Info_UI(RenderWindow window,Tower tower )
        {
            texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/MinionDescription.png"));
            sprite = new Sprite(texture);
            _drawed = false;
            //sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            sprite.Position = new Vector2f(333f, 70f);

            _window = window;
            _context = tower;
        }

        public void Draw(RenderWindow window)
        {
           
            window.Draw(sprite);
            float y = 0;
            foreach (Minion minion in _context.Summoner.Inventory.minionItem.Values.ToList())
            {
                text.DisplayedString = "Equiper  à " + minion.Name;
                text.Position = new Vector2f(sprite.Position.X + 5f, sprite.Position.Y + 5f + y*52f);
                text.FillColor = new Color(200, 0, 0);

                window.Draw(text);
                y++;
            }

        }
        public Equipement Equip
        {
            get { return equip; }
            set { equip = value; }
        }
        public bool Drawed
        {
            get { return _drawed; }
            set { _drawed = value; }
        }
    }
}
