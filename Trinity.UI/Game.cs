using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.IO;
using SFML.Audio;
using SFML.Window;
using System.Linq;

namespace Trinity.UI
{
    class Game
    {
        static RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(1700, 900), "Trinity");
        static Tower tower = new Tower();
        static Summoner summoner = tower.Summoner;
        static Inventory_UI inventory_UI = new Inventory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Inventory.png"), summoner, window);
        static Store_UI story_UI = new Store_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/shop.png"), tower, window);
        //static Armory_UI armory_UI = new Armory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/armory.png"), summoner, window);
        bool Onfight = false;
        bool launch_game = false;
        bool launch_history = false;
        bool launch_credit = false;
        //bool back_home = false;
        static Weaponry warriors = tower.Weaponry;
        FightUI fight_UI = new FightUI(window, tower);
        Option_Info_UI option = new Option_Info_UI(window, tower);
        Map map = new Map(window, "");
        Map fight_map = new Map(window, "fight");
        Player player = new Player(window);
        Music zelda_menu_music = new Music(Path.Combine(Directory.GetCurrentDirectory(), "../../../Music/Zelda_Menu_Music.ogg"));
        Music pokemon_fight_music = new Music(Path.Combine(Directory.GetCurrentDirectory(), "../../../Music/Pokemon_Fight_Music.ogg"));
        Menu menu = new Menu(window);
        Time time = new Time();
        Clock clock = new Clock();
        
        public void Start()
        {

            tower.Store.available();
            
            window.SetFramerateLimit(60);

            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
            window.MouseButtonPressed += Window_MouseButtonPressed;
      

            

            // Generation du player
            player = new Player(window);

            
            zelda_menu_music.Play();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                menu.Menu_Display();
                //PLAY
                if (launch_game == true)
                {
                    window.Clear();
                    map.Draw(window);
                    player.collide();

                    float deltaTime = clock.Restart().AsSeconds();

                    player.Update(deltaTime);
                    player.Draw(window);

                    if (player._Open_Shop == true)
                    {
                        story_UI.Draw(window);

                    }
                    else
                    {
                        story_UI.Drawed = false;
                    }

                    if (inventory_UI.Drawed) { inventory_UI.Draw(window); }
                    if (option != null && option.Drawed) { option.Draw(window); }

                    pokemon_fight_music.Volume = 20;
                    pokemon_fight_music.Play();
                    pokemon_fight_music.Loop = true;

                    if (Onfight)
                    {
                        fight_UI.Start();
                        fight_map.Draw(window);
                    }
                    
                    while (Onfight)
                    {
                        zelda_menu_music.Stop();

                       
                        int roundresult = fight_UI.Round(fight_map);





                        if (roundresult == 1)
                        {
                            Onfight = false;
                            tower.Boss.Inventory.Minion1.Bonus();
                            tower.Boss.Inventory.Minion2.Bonus();
                            tower.Boss.Inventory.Minion3.Bonus();

                            tower.Boss.Inventory.Minion1.Regen();
                            tower.Boss.Inventory.Minion2.Regen();
                            tower.Boss.Inventory.Minion3.Regen();
                        }
                        if (roundresult == -1)
                        {
                            Onfight = false;
                        }
                        zelda_menu_music.Play();
                    }

                }
                if(launch_history == true)
                {
                    window.Clear();
                    menu.History();
                }
                if(launch_credit == true)
                {
                    window.Clear();
                    menu.Credit();
                }
                //if(back_home == true)
                //{
                //    back_home = false;
                //    window.Clear();
                //    menu.Menu_Display();
                //}
                window.Display();

            }

        }

        private void Window_MouseMoved(object sender, MouseMoveEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.I)
            {
                inventory_UI.Drawed = !inventory_UI.Drawed;
            }
            if (e.Code == Keyboard.Key.S)
            {
                tower.Store.available();
            }
            if (e.Code == Keyboard.Key.F)
            {

                fight_UI.Start();
                Onfight = !Onfight;
            }
            //if (e.Code == Keyboard.Key.O /*&& player._Open_Shop == true*/)
            //{
            //}
        }
        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {

            if (e.Button == Mouse.Button.Left )
            {
                option.Drawed = false;
            }


            if (e.Button == Mouse.Button.Right)
            {

                Console.WriteLine(Mouse.GetPosition(window));
            }

            if (e.Button == Mouse.Button.Left && story_UI.Drawed)
            {
                for (int i = 0; i < 9; i++)
                {
                    if (672 + i * 62 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 726 + i * 62
                        && 284 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 338)
                    {
                        if (tower.Store.available_Equipement.Count > i) tower.Store.Buy_Equip(tower.Store.available_Equipement[i]);
                    }
                }
            }


            if (e.Button == Mouse.Button.Left && inventory_UI.Drawed)
            {
                var equip_inventory = tower.Summoner.Inventory.Equipement.Values.ToList();

                int y = 0;
                int i = 0;
                for (int nbinvent = 0; nbinvent < tower.Summoner.Inventory.Equipement.Count; nbinvent++)
                {
                    if (27 + i * 62 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 81 + i * 62
                        && 284 + y * 58 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 338 + y * 112)
                    {
                        option.Equip = equip_inventory[i+y*9];
                        option.Drawed = !option.Drawed;

                        
                    }
                    if (i == 8) { i = 0; y++ ; } else { i++; }
                }
            }
            if (option.Drawed)
            {
                //Console.WriteLine("equiper le minon 1");
                if (339 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 442
                    && 75 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 90)
                {
                    if(option.Equip is Weapon)
                    {
                        tower.Summoner.Inventory.Minion1.Armories.Equip((Weapon)option.Equip);
                        tower.Summoner.Inventory.RemovEquip(option.Equip);
                    } else
                        if(option.Equip is Hat)
                    {
                        tower.Summoner.Inventory.Minion1.Armories.Equip((Hat)option.Equip);
                    } else
                        if(option.Equip is Leg)
                    {
                        tower.Summoner.Inventory.Minion1.Armories.Equip((Leg)option.Equip);
                    } else
                        if(option.Equip is Breastplate)
                    {
                        tower.Summoner.Inventory.Minion1.Armories.Equip((Breastplate)option.Equip);
                    } else
                        if(option.Equip is Boots)
                    {
                        tower.Summoner.Inventory.Minion1.Armories.Equip((Boots)option.Equip);
                    }
                    tower.Summoner.Inventory.RemovEquip(option.Equip);
                    option.Drawed = false;

                }
                //Console.WriteLine("equiper le minon 2");

                if (337 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 446
                   && 129 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 142)
                {
                    if (option.Equip is Weapon)
                    {
                        tower.Summoner.Inventory.Minion2.Armories.Equip((Weapon)option.Equip);
                        
                    }
                    else
                        if (option.Equip is Hat)
                    {
                        tower.Summoner.Inventory.Minion2.Armories.Equip((Hat)option.Equip);
                    }
                    else
                        if (option.Equip is Leg)
                    {
                        tower.Summoner.Inventory.Minion2.Armories.Equip((Leg)option.Equip);
                    }
                    else
                        if (option.Equip is Breastplate)
                    {
                        tower.Summoner.Inventory.Minion2.Armories.Equip((Breastplate)option.Equip);
                    }
                    else
                        if (option.Equip is Boots)
                    {
                        tower.Summoner.Inventory.Minion2.Armories.Equip((Boots)option.Equip);
                    }
                    tower.Summoner.Inventory.RemovEquip(option.Equip);
                    option.Drawed = false;

                }
                //Console.WriteLine("equiper le minon 3");

                if (339 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 446
                   && 179 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 194)
                {
                    if (option.Equip is Weapon)
                    {
                        tower.Summoner.Inventory.Minion3.Armories.Equip((Weapon)option.Equip);
                      
                    }
                    else
                        if (option.Equip is Hat)
                    {
                        tower.Summoner.Inventory.Minion3.Armories.Equip((Hat)option.Equip);
                    }
                    else
                        if (option.Equip is Leg)
                    {
                        tower.Summoner.Inventory.Minion3.Armories.Equip((Leg)option.Equip);
                    }
                    else
                        if (option.Equip is Breastplate)
                    {
                        tower.Summoner.Inventory.Minion3.Armories.Equip((Breastplate)option.Equip);
                    }
                    else
                        if (option.Equip is Boots)
                    {
                        tower.Summoner.Inventory.Minion3.Armories.Equip((Boots)option.Equip);
                    }
                    tower.Summoner.Inventory.RemovEquip(option.Equip);
                    option.Drawed = false;

                }
            }
            if (e.Button == Mouse.Button.Left && Onfight)
            {

                if (620 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 1008
                   && 620 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 705 && !fight_UI.attak)
                {
                    fight_UI.attak = true;
                    fight_UI.FightBarSprite.Texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/fightbarAttak.png"));

                }
                if (fight_UI.attak)
                {

                    foreach (KeyValuePair<Minion, Sprite> pos in fight_UI.minionPos)
                    {
                        if (pos.Value.Position.X < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < pos.Value.Position.X + pos.Value.GetGlobalBounds().Width
                        && pos.Value.Position.Y < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < pos.Value.Position.Y + pos.Value.GetGlobalBounds().Height)
                        {



                            fight_UI.attak = false;
                            fight_UI.next = true;
                            fight_UI.targetMin = pos.Key;
                          
                        }


                    }

                }
            }
            if(e.Button == Mouse.Button.Left && launch_game == false)
            {
                //Launch game
                if(302 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 546
                    && 201 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 268/* && back_home == false*/)
                {
                    //Play();
                    launch_game = true;
                }
                //History
                if(304 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 544
                    && 403 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 466 && launch_history == false)
                {
                    launch_history = true;
                }
                //Credits
                if (302 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 543
                && 499 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 568 && launch_history == false)
                {
                    launch_credit = true;
                }
                //Quit game
                if (303 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 542 
                    && 674 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 735 && launch_history == false)
                {
                    Window_Closed(window, e);
                }
            }

        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}

            
