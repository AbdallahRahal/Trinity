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
        public List<Minion> Fighters = new List<Minion>();
        public List<Minion> SummMinions = new List<Minion>();
        List<Minion> BossMinions = new List<Minion>();
        BubbleFight bubbleFight;
        public Dictionary<Minion, Sprite> minionPos;
        BattlegroundFight battlegroundFight;
        public Sprite FightBarSprite;
        Texture FightBarTexture;
        public bool attak;
        int waithit = 0;
        Random rand = new Random();
        Minion minionAction;
        public Time time;
        Clock clock;
        public Minion focus = null;
        public Minion focusheal = null;
        float result;
        float decalX;
        float decalY;

        List<Minion> minionSummTargetList = new List<Minion>();
        List<Minion>  minionBossTargetList = new List<Minion>();
        public FightUI(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;
            FightBarTexture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/fightbar.png"));
            //FightBarTexture = new Texture("C:/S3/Trinity/Trinity.UI/Sprites/fightbar.png");
            
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
            minionPos = battlegroundFight.Start(Fighters);
            time = new Time();
            clock = new Clock();


        }
        public int Round(Map map, int minionRoundNum)
        {
            _window.Clear();

            time += clock.Restart();

            map.Draw(_window);
            

            _window.Draw(FightBarSprite);
            

            fighter_UI.Draw(Fighters,time.AsSeconds());
            

            minionPos = battlegroundFight.Draw(minionPos,focus,focusheal);
            

            bubbleFight.Draw();

            minionAction = timeLine[minionRoundNum];
            

            
            _window.Display();

           
            minionSummTargetList.Clear();
            minionBossTargetList.Clear();
           
            foreach (Minion minion in SummMinions)
            {
                if (minion.is_alive()) minionSummTargetList.Add(minion);
            }
            foreach (Minion minion in BossMinions)
            {
                if (minion.is_alive()) minionBossTargetList.Add(minion);
            }

            if (focusheal != null && !focusheal.is_alive()) focusheal = null;
            if (focus != null && !focus.is_alive()) focus = null;

            if (minionAction.is_alive())
            {

                if (minionAction.targetMin == minionAction)//je retourne a  la pos de base
                {
                    int summcount = 0;
                    int bosscount = 0;
                    foreach(Minion min in _context.Summoner.Inventory.Allminion())
                    {
                        if (minionAction == min)
                        {
                            if (minionPos[minionAction].Position.X > new Vector2f(400f * _window.Size.X / 1700f, (64f + summcount * 200f) * _window.Size.Y / 900f).X -10 &&
                                minionPos[minionAction].Position.X < new Vector2f(400f * _window.Size.X / 1700f, (64f + summcount * 200f) * _window.Size.Y / 900f).X +10 &&
                                minionPos[minionAction].Position.Y > new Vector2f(400f * _window.Size.X / 1700f, (64f + summcount * 200f) * _window.Size.Y / 900f).Y -10 &&
                                minionPos[minionAction].Position.Y < new Vector2f(400f * _window.Size.X / 1700f, (64f + summcount * 200f) * _window.Size.Y / 900f).Y +10)
                            {
                                minionAction.targetMin = null;
                            }
                            else
                            {
                                goToPosition(minionPos[minionAction], new Vector2f(400f * _window.Size.X / 1700f, (64f + summcount * 200f) * _window.Size.Y / 900f));
                            }
                           
                            
                        }
                        summcount++;
                    }

                    foreach (Minion min in _context.Boss.Inventory.Allminion())
                    {
                        if (minionAction == min)
                        {
                            if (minionPos[minionAction].Position.X > new Vector2f(1000f * _window.Size.X / 1700f, (64f + bosscount * 200f) * _window.Size.Y / 900f).X -10 &&
                                minionPos[minionAction].Position.X < new Vector2f(1000f * _window.Size.X / 1700f, (64f + bosscount * 200f) * _window.Size.Y / 900f).X +10 &&
                                minionPos[minionAction].Position.Y > new Vector2f(1000f * _window.Size.X / 1700f, (64f + bosscount * 200f) * _window.Size.Y / 900f).Y -10 &&
                                minionPos[minionAction].Position.Y < new Vector2f(1000f * _window.Size.X / 1700f, (64f + bosscount * 200f) * _window.Size.Y / 900f).Y +10)
                            {
                                minionAction.targetMin = null;
                            }
                            else
                            {
                                goToPosition(minionPos[minionAction], new Vector2f(1000f * _window.Size.X / 1700f, (64f + bosscount * 200f) * _window.Size.Y / 900f));
                            }
                            
                           
                        }
                        bosscount++;
                    }
                }
                else if (minionAction.targetMin == null)//j'ai pas de cible
                {
                    minionAction.last_attak = time.AsSeconds();

                    if (_context.Summoner.Inventory.ContainMinion(minionAction))
                    {
                        if (focus != null)
                        {
                            minionAction.targetMin = focus;
                        }
                        else
                        {
                            minionAction.targetMin = minionBossTargetList[rand.Next(minionBossTargetList.Count)];
                        }
                    }
                    else if (_context.Boss.Inventory.ContainMinion(minionAction))
                    {
                        minionAction.targetMin = minionSummTargetList[rand.Next(minionSummTargetList.Count)];
                    }
                }


                else if (minionAction.can_Attak(time.AsSeconds()))//j'attaque si je suis a porté
                {

                    decalX = vec(minionPos[minionAction].Position.X, minionPos[minionAction.targetMin].Position.X);
                    decalY = vec(minionPos[minionAction].Position.Y, minionPos[minionAction.targetMin].Position.Y);

                    if (decalX < 10 && decalY < 2 )
                    {
                        bubbleFight.Change_type(minionAction.dealDamage(minionAction.targetMin), minionPos[minionAction.targetMin]);
                        minionAction.targetMin = minionAction;
                    }
                    else
                    {
                        goToPosition(minionPos[minionAction], minionPos[minionAction.targetMin].Position);

                    }
                }
                
            }





            int alive = 0;
            
                foreach (Minion minion in SummMinions)
                {
                    if (minion.is_alive()) { alive++; }
                }
                if (alive == 0)
                {

                    Console.WriteLine("Le joueur a perdu");
                    return -1;
                }

                alive = 0;
                foreach (Minion minion in BossMinions)
                {
                    if (minion.is_alive()) { alive++; }
                }
                if (alive == 0)
                {
                    Console.WriteLine("Le Boss a perdu");
                    return 1;
                }
                
            
            return 0;


        }

        internal float vec(float a, float b)
        {
            result = Math.Abs(a - b)/8;
            return result;
        }

        internal void goToPosition(Sprite sprite,Vector2f position)
        {

            decalX = vec(sprite.Position.X, position.X);
            decalY = vec(sprite.Position.Y, position.Y);

            if (sprite.Position.X < position.X)
            {
                sprite.Position = new Vector2f(sprite.Position.X + decalX, sprite.Position.Y);
            }
            else
            if (sprite.Position.X > position.X)
            {
                sprite.Position = new Vector2f(sprite.Position.X - decalX, sprite.Position.Y);
            }
            if (sprite.Position.Y < position.Y)
            {
                sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y + decalY);
            }
            else
            if (sprite.Position.Y > position.Y)
            {
                sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y - decalY);
            }
            
        }
    }
}