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
    class FightUI
    {
        RenderWindow _window;
        Tower _context;
        List<Minion> timeLine = new List<Minion>();
        List<Minion> Fighters = new List<Minion>();
        Sprite FightBarSprite;
        Texture FightBarTexture;

        public FightUI(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;
            FightBarTexture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/fightbar.png"));
            FightBarSprite = new Sprite(FightBarTexture);
            FightBarSprite.Position = new Vector2f(29, 588);

        }

        internal void updateFighters()
        {
            Fighters.Clear();

            Fighters.Add(_context.Boss.Inventory.Minion1);
            Fighters.Add(_context.Boss.Inventory.Minion2);
            Fighters.Add(_context.Boss.Inventory.Minion3);

            Fighters.Add(_context.Summoner.Inventory.Minion1);
            Fighters.Add(_context.Summoner.Inventory.Minion2);
            Fighters.Add(_context.Summoner.Inventory.Minion3);
        }


        internal void updateTimeLine()
        {
            updateFighters();
            List<Minion> minionLead = Fighters;
           
            int topMinion = 0 ;

            while (timeLine.Count < 6)
            {
                uint ini = 0;
                for (int x = 0; x < minionLead.Count; x++)
                {
                    if (minionLead[x].Lead >= ini)
                    {
                        ini = minionLead[x].Lead;
                        topMinion = x;
                    }
                }

                timeLine.Add(minionLead[topMinion]);
                minionLead.Remove(minionLead[topMinion]);
            }
        }
        internal void DrawFightBar()
        {
            _window.Draw(FightBarSprite);
        }
        public void Start()
        {
            updateTimeLine();
            DrawFightBar();




        }
        public void Round()
        {
            DrawFightBar();






        }
    }
}
