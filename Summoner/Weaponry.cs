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
            Weapon sword_1 = tower.Equipement_Collection.Create_Weapon("Epee de Hulerion", 10, 50,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_sword.png"));
            Weapon sword_2 = tower.Equipement_Collection.Create_Weapon("Epee de Ultraran", 10, 50,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_sword.png"));

            Hat hat_1 = tower.Equipement_Collection.Create_Hat("Visère de Hulerion", 50, 10, 20, 2, 4, 25, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_hat.png"));
            Hat hat_2 = tower.Equipement_Collection.Create_Hat("Chapeau de Ultraran", 50, 10, 20, 2, 4, 30, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_hat.png"));

            Breastplate armor_1 = tower.Equipement_Collection.Create_Breastplate("Armure de Hulerion", 10, 10, 10, 10, 10, 35, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_breastplate.png"));
            Breastplate armor_2 = tower.Equipement_Collection.Create_Breastplate("Armure de Ultraran", 10, 10, 10, 10, 10, 35, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_breastplate.png"));
            
            Leg leg_1 = tower.Equipement_Collection.Create_Leg("Jambières de Hulerion", 10, 10 ,10, 10, 10, 10, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_leg.png"));
            Leg leg_2 = tower.Equipement_Collection.Create_Leg("Jambières de Ultraran", 10, 10, 10, 10, 10, 10, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_leg.png"));
            
            Boots boots_1 = tower.Equipement_Collection.Create_Boots("Chaussures de Hulerion", 5, 10, 10, 20, 4, 40,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_boots.png"));
            Boots boots_2 = tower.Equipement_Collection.Create_Boots("Chaussures de Ultraran", 5, 10, 10, 20, 4, 15,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_boots.png"));
            
            

            Minion minion1 = tower.Minion_Collection.Create_Minion("Allié 1", 20, 100, 1, 10, 79, 31, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));
            Minion minion2 = tower.Minion_Collection.Create_Minion("Allié 2", 12, 150, 200, 20, 90, 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Ryan.png"));
            Minion minion3 = tower.Minion_Collection.Create_Minion("Allié 3", 8, 210, 200, 5, 100, 95, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Abdel.png"));

            Minion minion4 = tower.Minion_Collection.Create_Minion("mechant 1", 15, 160, 100, 20, 85, 30, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/La fille de Morgan.png"));
            Minion minion5 = tower.Minion_Collection.Create_Minion("mechant 2", 10, 120, 65, 20, 100, 12, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Le fils de Ryan.png"));
            Minion minion6 = tower.Minion_Collection.Create_Minion("mechant 3", 5, 200, 65, 40, 80, 69, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Les fils d'Abdel.png"));

            tower.Summoner.Inventory.Attach_Minons(minion1);
            tower.Summoner.Inventory.Attach_Minons(minion2);
            tower.Summoner.Inventory.Attach_Minons(minion3);

            tower.Boss.Inventory.Attach_Minons(minion4);
            tower.Boss.Inventory.Attach_Minons(minion5);
            tower.Boss.Inventory.Attach_Minons(minion6);
        }
    }
}
