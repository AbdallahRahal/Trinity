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
        int Xdecal = 0;
        int Ydecal = 0;

        Dictionary<Minion, Sprite> minonPos = new Dictionary<Minion, Sprite> ();

        static Sprite spriteRound;
        static Texture textureRound;


        static Sprite spriteRoundheal;
        static Texture textureRoundheal;
        public BattlegroundFight(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;

            textureRound = new Texture((Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/TargetRound.png")));
            spriteRound = new Sprite(textureRound);
            spriteRound.Scale = new Vector2f(2 * _window.Size.X / 1700f, 2 * _window.Size.Y / 900f);


            textureRoundheal = new Texture((Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/TargetRoundheal.png")));
            spriteRoundheal = new Sprite(textureRoundheal);
            spriteRoundheal.Scale = new Vector2f(2 * _window.Size.X / 1700f, 2 * _window.Size.Y / 900f);
        }



        public Dictionary<Minion, Sprite> Start(List<Minion> _Fighters) // draw et return la pos de chaque minion dans un dictionnaire
        {
            int y = 0;
            int x = 0;

            foreach(Minion fighter in _Fighters)
            {
                texture = new Texture(fighter.Path);
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(2 * _window.Size.X / 1700f, 2 * _window.Size.Y / 900f);

                if (fighter.summMin())
                {
                    sprite.Position = new Vector2f(400f * _window.Size.X / 1700f, (64f + y * 200f) * _window.Size.Y / 900f);
                }
                else if (!fighter.summMin())
                {
                    sprite.Position = new Vector2f(1000 * _window.Size.X / 1700f, (64f + y * 200f) * _window.Size.Y / 900f);

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
                y++;
                if (y == 3) y = 0;



            }
            return minonPos;

        }


        public Dictionary<Minion, Sprite> Draw(Dictionary<Minion, Sprite> _Fighters, Minion focus,Minion focusheal) // draw et return la pos de chaque minion dans un dictionnaire
        {
            foreach (KeyValuePair<Minion, Sprite> fighter in _Fighters)
            {

                _window.Draw(fighter.Value);
                if (fighter.Key == focus)
                {
                    spriteRound.Position = fighter.Value.Position;
                    _window.Draw(spriteRound);

                }
                if (fighter.Key == focusheal)
                {
                    spriteRoundheal.Position = fighter.Value.Position;
                    _window.Draw(spriteRoundheal);

                }
            }
            return _Fighters;
        }
    }
}
