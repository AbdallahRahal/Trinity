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
        static Weaponry warriors = tower.Weaponry;

        public void Start()
        {

            tower.Store.Aviable();
            

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

            
