using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.IO;
using SFML.Window;

namespace Trinity.UI
{
    class Game
    {
        static RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Trinity");
        static Tower tower = new Tower();
        static Summoner summoner = new Summoner("Joueur", tower);
        static Inventory_UI inventory_UI = new Inventory_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Inventory.png"), summoner, window);
        static Store_UI story_UI = new Store_UI(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/shop.png"), tower, window);


        public void Start()
        {
            Weapon arc = tower.Equipement_Collection.Create_Weapon("Arc de Ryan",10, 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arc.png"));
            Weapon epee = tower.Equipement_Collection.Create_Weapon("epee de Ryan", 10, 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arc.png"));
            Hat bob = tower.Equipement_Collection.Create_Hat("bob de morgan", 50, 10, 20, 2, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));
            Boots lv = tower.Equipement_Collection.Create_Boots("lv", 5, 10, 10, 20, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));
            Boots nike = tower.Equipement_Collection.Create_Boots("nike", 5, 10, 10, 20, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));
            Hat carre = tower.Equipement_Collection.Create_Hat("Carré rouge",50,10,20,2, 4, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));
            Breastplate ocho = tower.Equipement_Collection.Create_Breastplate("quavo", 10, 10, 10, 10, 10, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arcc.png"));

            tower.Store.Aviable();
            List<Equipement> ma_liste = tower.Store.Aviable_Equipement;
            summoner.Inventory.AddEquip(arc);
            summoner.Inventory.AddEquip(carre);

            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;


            Map map = new Map(window);
            // Generation
            Player player = new Player(window);
            Clock clock = new Clock();


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
                if (player._Open_Shop == true )
                {
                    story_UI.Draw(window);
                    if (Keyboard.IsKeyPressed(Keyboard.Key.O))
                    {
                        player._Open_Shop = false;
                        story_UI.Drawed = !story_UI.Drawed;
                    }
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
            //if (e.Code == Keyboard.Key.O /*&& player._Open_Shop == true*/)
            //{
            //}
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
