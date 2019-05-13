using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;


//classe d'affichage du sprite d'option lors d'un click sur un item  pour l'equiper et deséquiper
namespace Trinity.UI
{
    class Option_Info_UI
    {
        Texture texture;
        Sprite sprite;
        Equipement _equipement;
        bool _drawed;


        public Option_Info_UI(RenderWindow window, Equipement equipement)
        {
            texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ItemDescription.png"));
            sprite = new Sprite(texture);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            _equipement = equipement;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }
        public bool Drawed
        {
            get{return _drawed ;}
            set { _drawed = value; }
        }
    }
}
