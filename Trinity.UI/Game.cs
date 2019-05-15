using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.IO;
using SFML.Audio;
using SFML.Window;

namespace Trinity.UI
{
    class Game
    {
        static RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(1700, 900), "Trinity");
        static Tower tower = new Tower();
        static Summoner summoner = tower.Summoner;
        static Inventory_UI inventory_UI = new Inventory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Inventory.png"), summoner, window);
        static Store_UI story_UI = new Store_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/shop.png"), tower, window);
        bool Onfight = false;

        public void Start()
        {
            Weapon arc = tower.Equipement_Collection.Create_Weapon("Arc de Ryan", 10, 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arc.png"));
            Weapon epee = tower.Equipement_Collection.Create_Weapon("epee de Ryan", 10, 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/epee.png"));
            Hat bob = tower.Equipement_Collection.Create_Hat("bob de morgan", 50, 10, 20, 2, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bob.jpg"));
            Boots lv = tower.Equipement_Collection.Create_Boots("lv", 5, 10, 10, 20, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/boot1.png"));
            Boots nike = tower.Equipement_Collection.Create_Boots("nike", 5, 10, 10, 20, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/boot2.png"));
            Hat carre = tower.Equipement_Collection.Create_Hat("Carré rouge", 50, 10, 20, 2, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/chapeau.png"));
            Breastplate ocho = tower.Equipement_Collection.Create_Breastplate("quavo", 10, 10, 10, 10, 10, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/quavo.jpg"));
            //Leg jambiere = tower.Equipement_Collection.Create_Leg("Jambier des z'homme", 1000, 10,50,20,50,)
            Minion minion1 = tower.Minion_Collection.Create_Minion("Morgan", 100, 100, 100, 20, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));
            Minion minion2 = tower.Minion_Collection.Create_Minion("Mergi", 50, 23, 65, 0, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));

            tower.Store.Aviable();
            List<Equipement> ma_liste = tower.Store.Aviable_Equipement;
            

            summoner.Inventory.Attach_Minons(minion1);
            summoner.Inventory.Attach_Minons(minion2);


            window.SetFramerateLimit(60);

            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
            window.MouseButtonPressed += Window_MouseButtonPressed;

            Map map = new Map(window, "");
            Map fight_map = new Map(window, "fight");
            Player player = new Player(window);
            Clock clock = new Clock();

            // Generation du player
            player = new Player(window);

            Music zelda_menu_music = new Music(Path.Combine(Directory.GetCurrentDirectory(), "../../../Music/Zelda_Menu_Music.ogg"));
            Music pokemon_fight_music = new Music(Path.Combine(Directory.GetCurrentDirectory(), "../../../Music/Pokemon_Fight_Music.ogg"));
            zelda_menu_music.Play();
            zelda_menu_music.Loop = true;
            while (window.IsOpen)
            {
                
                window.DispatchEvents();
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
                pokemon_fight_music.Volume = 20;
                pokemon_fight_music.Play();
                pokemon_fight_music.Loop = true;

                while (Onfight)
                {
                    zelda_menu_music.Stop();
                    window.DispatchEvents();
                    window.Clear();
                    fight_map.Draw(window);
                    player.Draw(window);
                    window.Display();
                    zelda_menu_music.Play();
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
            }
            if (e.Code == Keyboard.Key.S)
            {
                tower.Store.Aviable();
            }
            if (e.Code == Keyboard.Key.F)
            {
                Onfight = !Onfight;
            }
            //if (e.Code == Keyboard.Key.O /*&& player._Open_Shop == true*/)
            //{
            //}
        }
        private void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left && story_UI.Drawed)
            {
               

                for (int i = 0; i < 9; i++)
                {
                    if (672 + i * 62 < Mouse.GetPosition(window).X && Mouse.GetPosition(window).X < 726 + i * 62
                        && 284 < Mouse.GetPosition(window).Y && Mouse.GetPosition(window).Y < 338)
                    {
                        if (tower.Store.Aviable_Equipement.Count > i) tower.Store.Buy_Equip(tower.Store.Aviable_Equipement[i]);
                    }
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

            
