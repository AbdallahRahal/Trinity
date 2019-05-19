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

        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Texte option equipement", font, 12);


        public Option_Info_UI(RenderWindow window, Equipement equipement)
        {
            texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/MinionDescription.png"));
            sprite = new Sprite(texture);
            _drawed = false;
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);
            sprite.Position = new Vector2f(Mouse.GetPosition(window).X+100f, Mouse.GetPosition(window).Y+100f);
            _equipement = equipement;
        }

        public void Draw(RenderWindow window)
        {
            _drawed = true;

            text.DisplayedString = "Equiper Minion 1";
            text.Position = new Vector2f(Mouse.GetPosition(window).X, Mouse.GetPosition(window).Y + 20f);
            text.FillColor = new Color(200, 0, 0);

            window.Draw(sprite);
            window.Draw(text);

        }
        public bool Drawed
        {
            get{return _drawed ;}
            set { _drawed = value; }
        }
    }
}
