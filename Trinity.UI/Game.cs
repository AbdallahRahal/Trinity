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
        //static Music music = new Music("../../../Music/Bloodytears.mp3");
        static Tower tower = new Tower();
        static Summoner summoner = new Summoner("Joueur", tower);
        static Inventory_UI inventory_UI = new Inventory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Inventory.png"), summoner, window);
        bool Onfight = false;
        public void Start()
        {
           
            Weapon arc = tower.Equipement_Collection.Create_Weapon("Arc de Ryan", 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arc.png"));
            Hat carre = tower.Equipement_Collection.Create_Hat("Carré rouge",50,20,2, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));

           summoner.Inventory.AddEquip(arc);
           summoner.Inventory.AddEquip(carre);

            
            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;


            Map map = new Map(window,"");
            Map fight_map = new Map(window,"fight");

            // Generation
            Player player = new Player(window);

            Clock clock = new Clock();
            Music music = new Music(Path.Combine(Directory.GetCurrentDirectory(), "../../../Music/Menu_Zelda.ogg"));
            music.Play();

            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear();
                map.Draw(window);
                player.collide();

                float deltaTime = clock.Restart().AsSeconds();

                player.Update(deltaTime);
                player.Draw(window);

                if (inventory_UI.Drawed) { inventory_UI.Draw(window); }
               
                while (Onfight)
                {
                    window.DispatchEvents();
                    window.Clear();

                    fight_map.Draw(window);

                    window.Display();
                }

                window.Display();
            }


        }

      private  void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.I)
            {
                inventory_UI.Drawed = !inventory_UI.Drawed;

            }
            if (e.Code == Keyboard.Key.F)
            {
                Onfight = !Onfight;

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
