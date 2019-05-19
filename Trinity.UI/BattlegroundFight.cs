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

        Dictionary<Minion, Sprite> minonPos = new Dictionary<Minion, Sprite> ();

        static Sprite spriteRound;
        static Texture textureRound;

        public BattlegroundFight(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;

            textureRound = new Texture((Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/TargetRound.png")));
            spriteRound = new Sprite(textureRound);

            spriteRound.Scale = new Vector2f(2 * _window.Size.X / 1700f, 2 * _window.Size.Y / 900f);

        }
        public Dictionary<Minion, Sprite> Draw(List<Minion> _Fighters,Minion minRound) // draw et return la pos de chaque minion dans un dictionnaire
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

                if (minonPos.ContainsKey(fighter))
                {
                    
                    minonPos[fighter] = sprite;
                }
                else
                {
                    minonPos.Add(fighter, sprite);
                }




                _window.Draw(sprite);
                if (fighter.Name == minRound.Name)
                {
                    spriteRound.Position = sprite.Position;
                    _window.Draw(spriteRound);
                }


                y++;
                if (y == 3) y = 0; 
            }
            return minonPos;
        }
        



    }
}
