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
        Fighter_UI fighter_UI;
        List<Minion> timeLine = new List<Minion>();
        List<Minion> Fighters = new List<Minion>();
        List<Minion> SummMinions = new List<Minion>();
        List<Minion> BossMinions = new List<Minion>();
        bool SummAlive;
        bool BossAlive;
        BubbleFight bubbleFight;
        public Dictionary<Minion, Sprite> minionPos;
       BattlegroundFight battlegroundFight;
        public Minion targetMin;
        public Sprite FightBarSprite;
        Texture FightBarTexture;
        public bool next;
        public bool attak;

        public FightUI(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;
            FightBarTexture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/fightbar.png"));
            FightBarSprite = new Sprite(FightBarTexture);
            FightBarSprite.Position = new Vector2f(29, 588);
            battlegroundFight = new BattlegroundFight(window, tower);
            bubbleFight = new BubbleFight(window, tower);

        }

        internal void updateFighters()
        {
            Fighters.Clear();
            BossMinions.Clear();
            SummMinions.Clear();


            Fighters.Add(_context.Boss.Inventory.Minion1);
            Fighters.Add(_context.Boss.Inventory.Minion2);
            Fighters.Add(_context.Boss.Inventory.Minion3);

            BossMinions.Add(_context.Boss.Inventory.Minion1);
            BossMinions.Add(_context.Boss.Inventory.Minion2);
            BossMinions.Add(_context.Boss.Inventory.Minion3);


            Fighters.Add(_context.Summoner.Inventory.Minion1);
            Fighters.Add(_context.Summoner.Inventory.Minion2);
            Fighters.Add(_context.Summoner.Inventory.Minion3);


            SummMinions.Add(_context.Summoner.Inventory.Minion1);
            SummMinions.Add(_context.Summoner.Inventory.Minion2);
            SummMinions.Add(_context.Summoner.Inventory.Minion3);

            SummAlive = true;
            BossAlive = true;
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
        public void Start()
        {
            updateTimeLine();
            fighter_UI = new Fighter_UI(_window,_context ,Fighters);
           


        }
        public int Round(Map map)
        {
            

            for (int playerRoundNum = 0; playerRoundNum < timeLine.Count; playerRoundNum++)
            {
               
               

                Action(timeLine[playerRoundNum],map, playerRoundNum);


                int alive = 0;
                foreach (Minion minion in SummMinions)
                {
                    if (minion.is_alive()) { alive++; }
                }
                if (alive == 0)
                {
                    Console.WriteLine("Le joueur a perdu");
                    return 1;
                }

                alive = 0;
                foreach (Minion minion in BossMinions)
                {
                    if (minion.is_alive()) { alive++; }
                }
                if (alive == 0)
                {
                    Console.WriteLine("Le Boss a perdu");
                    return -1;
                }
                
            }
            return 0;


        }

        internal void Action(Minion minionAction, Map map, int playerRoundNum)
        {
           
            this.next = false;
            while (this.next == false)
            {
                _window.Clear();
                map.Draw(_window);
                _window.Draw(FightBarSprite);
                fighter_UI.Draw(Fighters, timeLine[playerRoundNum]);
                minionPos = battlegroundFight.Draw(Fighters, timeLine[playerRoundNum]);
                _window.Display();

                if (_context.Summoner.Inventory.ContainMinion(minionAction))
                {

                    _window.DispatchEvents();
                    if (targetMin != null)
                    {
                        bubbleFight.Change_type(minionAction.dealDamage(targetMin),this);
                        targetMin = null;
                        FightBarSprite.Texture  = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/fightbar.png"));
                        
                    }

                }
                if (_context.Boss.Inventory.ContainMinion(minionAction) )
                {
                    Random rand = new Random();

                    System.Threading.Thread.Sleep(rand.Next(1000, 3000));
                    Console.WriteLine("tour de " + minionAction.Name + " appartient au Boss");

                    List<Minion> targetList = new List<Minion>();
                    foreach (Minion minion in SummMinions)
                    {
                        if (minion.is_alive()) targetList.Add(minion);
                    }

                    int target = rand.Next(targetList.Count);

                    //bubbleFight.Change_type(minionAction.dealDamage(targetList[target]),);



                    this.next = true;
                }
            }

            
        }


    }
}
