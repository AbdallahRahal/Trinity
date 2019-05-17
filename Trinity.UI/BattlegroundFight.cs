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
    class BattlegroundFight
    {
        RenderWindow _window;
        Tower _context;
        static Sprite sprite;
        static Texture texture;

        public BattlegroundFight(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;

        }
        public void Draw(List<Minion> _Fighters)
        {
            int y = 0;
            int x = 0;

            foreach (Minion fighter in _Fighters)
            {
                texture = new Texture(fighter.Path);
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(2 * _window.Size.X / 1700f,  2 * _window.Size.Y / 900f);

                if (fighter.summMin())
                {
                    sprite.Position = new Vector2f(291f * _window.Size.X / 1700f, (64f + y * 200f) * _window.Size.Y / 900f);
                }
                else
                {
                    sprite.Position = new Vector2f(1160 * _window.Size.X / 1700f, (64f + y * 200f) * _window.Size.Y / 900f);

                }






                _window.Draw(sprite);
                y++;
                if (y == 3) y = 0;
            }

        }
    }
}
