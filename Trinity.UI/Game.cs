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
        static Armory_UI armory_UI = new Armory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/armory.png"), summoner, window);
        static Options_UI options_UI = new Options_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/options.png"), summoner, window);
        static DragAndDrop_Sprite DragAndDrop_Sprite = new DragAndDrop_Sprite(window, tower);
        static Minion[] minionTab = new Minion[3];

        bool Onfight = false;
        bool launch_game = false;
        bool launch_history = false;
        bool back_home = false;
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
        int minionRoundNum;

        public void Start()
        {

            tower.Store.available();
            window.SetFramerateLimit(120);

            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
            window.MouseButtonPressed += Window_MouseButtonPressed;
            window.MouseButtonReleased += Window_MouseButtonReleased;




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
                    options_UI.Draw(window);



                    // Ouverture du shop
                    if (player._Open_Shop == true)
                {
                    story_UI.Draw(window);
                }
                else
                {
                    story_UI.Drawed = false;
                }
                
                // Ouverture de l'inventaire & des inventaires des minions
                if (inventory_UI.Drawed)
                {
                    inventory_UI.Draw(window);
                    armory_UI.Draw(window);
                }


                if (DragAndDrop_Sprite.Drawed)
                {
                    DragAndDrop_Sprite.Draw(window);
                }

                    if (option != null && option.Drawed) { option.Draw(window); }
               
                pokemon_fight_music.Volume = 20;
                pokemon_fight_music.Play();
                pokemon_fight_music.Loop = true;

                    pokemon_fight_music.Volume = 20;
                    pokemon_fight_music.Play();
                    pokemon_fight_music.Loop = true;

                    if (Onfight)
                    {
                        fight_UI.Start();
                        fight_map.Draw(window);
                        minionRoundNum = 0;
                    }
                    
                    while (Onfight)
                    {
                        //zelda_menu_music.Stop();
                        
                        window.DispatchEvents();
                        int roundresult = fight_UI.Round(fight_map,minionRoundNum);
                        minionRoundNum++;
                        if (minionRoundNum == 6)
                        {
                            minionRoundNum = 0;
                        }



                        if (roundresult == 1 || roundresult == -1)
                        {
                            Onfight = false;

                            fight_UI.focus = null;
                            fight_UI.focusheal = null;
                            tower.Boss.Inventory.Minion1.Regen();
                            tower.Boss.Inventory.Minion2.Regen();
                            tower.Boss.Inventory.Minion3.Regen();


                            tower.Summoner.Inventory.Minion1.Regen();
                            tower.Summoner.Inventory.Minion2.Regen();
                            tower.Summoner.Inventory.Minion3.Regen();
                        }if(roundresult == -1)
                        {
                            tower.Boss.Inventory.Minion1.Bonus();
                            tower.Boss.Inventory.Minion2.Bonus();
                            tower.Boss.Inventory.Minion3.Bonus();
                        }
                        //zelda_menu_music.Play();
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
                if (back_home == true)
                {
                    window.Clear();
                    menu.Menu_Display();
                }
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
                armory_UI.Drawed = !armory_UI.Drawed;
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
        }
        private void Window_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left && DragAndDrop_Sprite.Drawed)
            {
                Equipement Equipp;
                DragAndDrop_Sprite.Drawed = false;
                Equipp = DragAndDrop_Sprite.equip;
                DragAndDrop_Sprite.equip = null;
                minionTab[0] = summoner.Inventory.Minion1;
                minionTab[1] = summoner.Inventory.Minion2;
                minionTab[2] = summoner.Inventory.Minion3;
                foreach (Minion minion in minionTab)
                {
                    if (minion.Armories.Weapon == null)
                    {
                        if (((float)Mouse.GetPosition(window).X > 106 && (float)Mouse.GetPosition(window).X < 160 &&
                        (float)Mouse.GetPosition(window).Y > 665 && (float)Mouse.GetPosition(window).Y < 719))
                        {
                            summoner.Inventory.Minion1.Armories.Equip((Weapon)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 306 && (float)Mouse.GetPosition(window).X < 360 &&
                        (float)Mouse.GetPosition(window).Y > 665 && (float)Mouse.GetPosition(window).Y < 719))
                        {
                            tower.Summoner.Inventory.Minion2.Armories.Equip((Weapon)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 506 && (float)Mouse.GetPosition(window).X < 560 &&
                        (float)Mouse.GetPosition(window).Y > 665 && (float)Mouse.GetPosition(window).Y < 719))
                        {
                            tower.Summoner.Inventory.Minion3.Armories.Equip((Weapon)Equipp);
                        }
                    }

                    if (minion.Armories.Gem == null)
                    {
                        if (((float)Mouse.GetPosition(window).X > 106 && (float)Mouse.GetPosition(window).X < 160 &&
                        (float)Mouse.GetPosition(window).Y > 728 && (float)Mouse.GetPosition(window).Y < 782))
                        {
                            tower.Summoner.Inventory.Minion1.Armories.Equip((Gem)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 306 && (float)Mouse.GetPosition(window).X < 360 &&
                        (float)Mouse.GetPosition(window).Y > 728 && (float)Mouse.GetPosition(window).Y < 782))
                        {
                            tower.Summoner.Inventory.Minion2.Armories.Equip((Gem)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 506 && (float)Mouse.GetPosition(window).X < 560 &&
                        (float)Mouse.GetPosition(window).Y > 728 && (float)Mouse.GetPosition(window).Y < 782))
                        {
                            tower.Summoner.Inventory.Minion3.Armories.Equip((Gem)Equipp);
                        }
                    }

                    if (minion.Armories.Hat == null)
                    {
                        if (((float)Mouse.GetPosition(window).X > 16 && (float)Mouse.GetPosition(window).X < 70 &&
                        (float)Mouse.GetPosition(window).Y > 578 && (float)Mouse.GetPosition(window).Y < 632))
                        {
                            tower.Summoner.Inventory.Minion1.Armories.Equip((Hat)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 216 && (float)Mouse.GetPosition(window).X < 270 &&
                        (float)Mouse.GetPosition(window).Y > 578 && (float)Mouse.GetPosition(window).Y < 632))
                        {
                            tower.Summoner.Inventory.Minion2.Armories.Equip((Hat)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 416 && (float)Mouse.GetPosition(window).X < 470 &&
                        (float)Mouse.GetPosition(window).Y > 578 && (float)Mouse.GetPosition(window).Y < 632))
                        {
                            tower.Summoner.Inventory.Minion3.Armories.Equip((Hat)Equipp);
                        }
                    }

                    if (minion.Armories.Breastplate == null)
                    {
                        if (((float)Mouse.GetPosition(window).X > 16 && (float)Mouse.GetPosition(window).X < 70 &&
                        (float)Mouse.GetPosition(window).Y > 639 && (float)Mouse.GetPosition(window).Y < 692))
                        {
                            tower.Summoner.Inventory.Minion1.Armories.Equip((Breastplate)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 216 && (float)Mouse.GetPosition(window).X < 270 &&
                        (float)Mouse.GetPosition(window).Y > 639 && (float)Mouse.GetPosition(window).Y < 692))
                        {
                            tower.Summoner.Inventory.Minion2.Armories.Equip((Breastplate)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 416 && (float)Mouse.GetPosition(window).X < 470 &&
                        (float)Mouse.GetPosition(window).Y > 639 && (float)Mouse.GetPosition(window).Y < 692))
                        {
                            tower.Summoner.Inventory.Minion3.Armories.Equip((Breastplate)Equipp);
                        }
                    }

                    if (minion.Armories.Leg == null)
                    {
                        if (((float)Mouse.GetPosition(window).X > 16 && (float)Mouse.GetPosition(window).X < 70 &&
                        (float)Mouse.GetPosition(window).Y > 699 && (float)Mouse.GetPosition(window).Y < 753))
                        {
                            tower.Summoner.Inventory.Minion1.Armories.Equip((Leg)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 216 && (float)Mouse.GetPosition(window).X < 270 &&
                        (float)Mouse.GetPosition(window).Y > 699 && (float)Mouse.GetPosition(window).Y < 753))
                        {
                            tower.Summoner.Inventory.Minion2.Armories.Equip((Leg)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 416 && (float)Mouse.GetPosition(window).X < 470 &&
                        (float)Mouse.GetPosition(window).Y > 699 && (float)Mouse.GetPosition(window).Y < 753))
                        {
                            tower.Summoner.Inventory.Minion3.Armories.Equip((Leg)Equipp);
                        }
                    }

                    if (minion.Armories.Boots == null)
                    {
                        if (((float)Mouse.GetPosition(window).X > 16 && (float)Mouse.GetPosition(window).X < 70 &&
                        (float)Mouse.GetPosition(window).Y > 759 && (float)Mouse.GetPosition(window).Y < 813))
                        {
                            tower.Summoner.Inventory.Minion1.Armories.Equip((Boots)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 216 && (float)Mouse.GetPosition(window).X < 270 &&
                        (float)Mouse.GetPosition(window).Y > 759 && (float)Mouse.GetPosition(window).Y < 813))
                        {
                            tower.Summoner.Inventory.Minion2.Armories.Equip((Boots)Equipp);
                        }
                        if (((float)Mouse.GetPosition(window).X > 416 && (float)Mouse.GetPosition(window).X < 470 &&
                        (float)Mouse.GetPosition(window).Y > 759 && (float)Mouse.GetPosition(window).Y < 813))
                        {
                            tower.Summoner.Inventory.Minion3.Armories.Equip((Boots)Equipp);
                        }
                    }
                }
            }
        }

            private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
            {
            
            if (e.Button == Mouse.Button.Left)
            {
                // ouvrir les options
                if (((float)Mouse.GetPosition(window).X > 1545 && (float)Mouse.GetPosition(window).X < 1580 &&
                (float)Mouse.GetPosition(window).Y > 5 && (float)Mouse.GetPosition(window).Y < 44))
                {
                    options_UI.Draw_Options = true;
                }
                // fermer les options
                if (((float)Mouse.GetPosition(window).X > 1175 && (float)Mouse.GetPosition(window).X < 1200 &&
                (float)Mouse.GetPosition(window).Y > 115 && (float)Mouse.GetPosition(window).Y < 145))
                {
                    options_UI.Draw_Options = false;
                }
                // quitter le jeu
                if (((float)Mouse.GetPosition(window).X > 1648 && (float)Mouse.GetPosition(window).X < 1685 &&
                (float)Mouse.GetPosition(window).Y > 6 && (float)Mouse.GetPosition(window).Y < 43))
                {
                    ;
                }
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
                        DragAndDrop_Sprite.equip = equip_inventory[i + y * 9];
                        DragAndDrop_Sprite.Drawed = true;
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
                    else
                        if (option.Equip is Gem)
                    {
                        tower.Summoner.Inventory.Minion1.Armories.Equip((Gem)option.Equip);
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
                    else
                        if (option.Equip is Gem)
                    {
                        tower.Summoner.Inventory.Minion2.Armories.Equip((Gem)option.Equip);
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
                    else
                        if (option.Equip is Gem)
                    {
                        tower.Summoner.Inventory.Minion3.Armories.Equip((Gem)option.Equip);
                    }
                    tower.Summoner.Inventory.RemovEquip(option.Equip);
                    option.Drawed = false;

                }
            }
            if (e.Button == Mouse.Button.Left && Onfight)
            {
                //FOCUS A ENVOYER QUE SI MINION ALLI2 TAPE et fighter envoyer que quand en vie

                int y = 0;
                foreach (Minion min in fight_UI.SummMinions)
                {
                    if (555f < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 555f + 50f
                        && (640f + y *70f) < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < (690f + y * 70f))
                    {
                        min.Armories.Gem.action(fight_UI.Fighters, fight_UI.focus, fight_UI.focusheal, fight_UI.time.AsSeconds());
                    }
                    

                    y++;
                    

                }







                foreach (KeyValuePair<Minion, Sprite> pos in fight_UI.minionPos)
                {
                    if (pos.Value.Position.X < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < pos.Value.Position.X + pos.Value.GetGlobalBounds().Width
                    && pos.Value.Position.Y < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < pos.Value.Position.Y + pos.Value.GetGlobalBounds().Height)
                    {
                        if (tower.Boss.Inventory.ContainMinion(pos.Key) && pos.Key.is_alive()){
                            if (fight_UI.focus != null && fight_UI.focus == pos.Key)
                            {
                                fight_UI.focus = null;
                            }
                            else
                            {
                                fight_UI.focus = pos.Key;
                                foreach (Minion min in tower.Summoner.Inventory.Allminion())
                                {
                                    if (min.targetMin != min)
                                    {
                                        min.targetMin = pos.Key;
                                    }
                                }
                            }
                        }
                        if (tower.Summoner.Inventory.ContainMinion(pos.Key) && pos.Key.is_alive())
                        {
                            if (fight_UI.focusheal != null && fight_UI.focusheal == pos.Key)
                            {
                                fight_UI.focusheal = null;
                            }
                            else
                            {
                                fight_UI.focusheal = pos.Key;
                            }
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
                    back_home = false;
                }
                //Credits
                if (302 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 543
                && 499 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 568 && launch_history == false)
                {
                    launch_credit = true;
                    back_home = false;
                }
                //Back Home
                if (247 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 393
                && 670 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 716 && back_home == false)
                {
                    back_home = true;
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

            
