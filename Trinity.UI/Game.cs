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
           static Tower tower = new Tower();
        static Summoner summoner = new Summoner("Joueur", tower);
        static Inventory_UI inventory_UI = new Inventory_UI("C:/S3/Trinity/Trinity.UI/Resources/Inventory.png", summoner);
         
        public void Start()
        {
            Weapon arc = tower.Equipement_Collection.Create_Weapon("Arc de Ryan", 50, "C:/S3/Trinity/Trinity.UI/Resources/arc.png");
            Weapon arcc = tower.Equipement_Collection.Create_Weapon("Arc de Ryyan", 50, "C:/S3/Trinity/Trinity.UI/Resources/arcc.png");

            summoner.Inventory.AddEquip(arc);
            summoner.Inventory.AddEquip(arcc);

            RenderWindow window = new RenderWindow(new SFML.Window.VideoMode(1700, 900), "Trinity");
            window.SetFramerateLimit(60);
            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
            
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(new Color(43, 100, 0, 0));

                

                if (inventory_UI.Drawed) { inventory_UI.Draw(window); }


                window.Display();
            }


        }


      private  void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Code == Keyboard.Key.I)
            {
                inventory_UI.Drawed = !inventory_UI.Drawed;
                
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }
    }
}
