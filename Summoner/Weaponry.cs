using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Trinity
{
    public class Weaponry
    {
        Tower tower;

        public Weaponry(Tower tower)
        {
            Weapon arc = tower.Equipement_Collection.Create_Weapon("Arc de Ryan", 10, 50,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/arc.png"));
            Weapon epee = tower.Equipement_Collection.Create_Weapon("epee de Ryan", 10, 50,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/epee.png"));
            Hat bob = tower.Equipement_Collection.Create_Hat("bob de morgan", 50, 10, 20, 2, 4, 30,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/bob.jpg"));
            Boots lv = tower.Equipement_Collection.Create_Boots("lv", 5, 10, 10, 20, 4, 40,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/boot1.png"));
            Boots nike = tower.Equipement_Collection.Create_Boots("nike", 5, 10, 10, 20, 4, 15,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/boot2.png"));
            Hat carre = tower.Equipement_Collection.Create_Hat("Carré rouge", 50, 10, 20, 2, 4, 25,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/chapeau.png"));
            Breastplate ocho = tower.Equipement_Collection.Create_Breastplate("quavo", 10, 10, 10, 10, 10, 35,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/quavo.jpg"));

            Minion minion1 = tower.Minion_Collection.Create_Minion("Morgan", 100, 100, 100, 20, 20,30, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));
            Minion minion2 = tower.Minion_Collection.Create_Minion("Ryaan", 50, 23, 65, 0, 20, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));
            Minion minion3 = tower.Minion_Collection.Create_Minion("Abdel", 50, 23, 65, 0, 20, 0, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));

            tower.Summoner.Inventory.Attach_Minons(minion1);
            tower.Summoner.Inventory.Attach_Minons(minion2);
            tower.Summoner.Inventory.Attach_Minons(minion3);
        }
    }
}
