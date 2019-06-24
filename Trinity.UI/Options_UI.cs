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
    class Options_UI
    {
        public float Xpos;
        public float Ypos;
        Sprite sprite;
        Texture texture;
        bool _draw;
        bool _options_draw;
        Summoner _summoner;
        Sprite optionsSprite = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/optionsSprite.png")));

        RenderWindow _window;

        public Options_UI(string filename, Summoner summoner, RenderWindow window)
        {
            texture = new Texture(filename);
            sprite = new Sprite(texture);
            _draw = false;
            _window = window;
            _summoner = summoner;
        }


        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
            sprite.Position = new Vector2f(1530, 0);
            if (Draw_Options)
            {
                optionsSprite.Position = new Vector2f(448, 100);
                _window.Draw(optionsSprite);
            }
           
        }

        public bool Draw_Options
        { 
             get { return _options_draw; }
            set { _options_draw = value; }
        }
        public bool Drawed
        {
            get { return _draw; }
            set { _draw = value; }
        }
    }
}