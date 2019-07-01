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
    class DragAndDrop_Sprite
    {
        public Equipement equip;
        RenderWindow _window;
        Tower _context;
        bool _draw;
        Sprite sprite;

        public DragAndDrop_Sprite(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;
        }

        public void Draw(RenderWindow window)
        {
            sprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), equip.Path)));
            sprite.Position = (Vector2f)Mouse.GetPosition(window);
            window.Draw(sprite);
        }

        public bool Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }
    }
}
