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


            Gem electrocute = tower.Equipement_Collection.Create_Gem("electrocute","electrocute", 2000, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/electrocute_gem.png"));
            Gem heal = tower.Equipement_Collection.Create_Gem("soin","heal", 2000, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/heal_gem.png"));

            Weapon sword_1 = tower.Equipement_Collection.Create_Weapon("Epee de Hulerion", 10, 50,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_sword.png"));
            Weapon sword_2 = tower.Equipement_Collection.Create_Weapon("Epee de Ultraran", 10, 50,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_sword.png"));

            Hat hat_1 = tower.Equipement_Collection.Create_Hat("Visère de Hulerion", 50, 10, 20, 2, 4, 2, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_hat.png"));
            Hat hat_2 = tower.Equipement_Collection.Create_Hat("Chapeau de Ultraran", 50, 10, 20, 2, 4, 3, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_hat.png"));

            Breastplate armor_1 = tower.Equipement_Collection.Create_Breastplate("Armure de Hulerion", 10, 10, 10, 10, 10, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_breastplate.png"));
            Breastplate armor_2 = tower.Equipement_Collection.Create_Breastplate("Armure de Ultraran", 10, 10, 10, 10, 10, 3, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_breastplate.png"));
            
            Leg leg_1 = tower.Equipement_Collection.Create_Leg("Jambières de Hulerion", 10, 10 ,10, 10, 10, 50, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_leg.png"));
            Leg leg_2 = tower.Equipement_Collection.Create_Leg("Jambières de Ultraran", 10, 10, 10, 10, 10, 3, Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_leg.png"));
            
            Boots boots_1 = tower.Equipement_Collection.Create_Boots("Chaussures de Hulerion", 5, 10, 10, 20, 4, 3,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/hulerion_boots.png"));
            Boots boots_2 = tower.Equipement_Collection.Create_Boots("Chaussures de Ultraran", 5, 10, 10, 20, 4, 3,Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/ultraran_boots.png"));
            
            

            Minion minion1 = tower.Minion_Collection.Create_Minion("Allié 1", 20, 100,   1, 10,  90, 5, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Morgan.png"));
            Minion minion2 = tower.Minion_Collection.Create_Minion("Allié 2", 12, 150, 200, 15,  90, 10, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Ryan.png"));
            Minion minion3 = tower.Minion_Collection.Create_Minion("Allié 3",  8, 210, 200,  5, 100, 20, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Abdel.png"));

            Minion BossMinion1 = tower.Minion_Collection.Create_Minion("Méchant 1", 15, 360, 100,  20,  98, 1, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/La fille de Morgan.png"));
            Minion BossMinion2 = tower.Minion_Collection.Create_Minion("Méchant 2", 10, 200,  90,  20, 100, 12, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Le fils de Ryan.png"));
            Minion BossMinion3 = tower.Minion_Collection.Create_Minion("Méchant 3",  5, 700,  95, 20,  92, 19, Path.Combine(Directory.GetCurrentDirectory(), "../../../MinionSprites/Les fils d'Abdel.png"));

            tower.Summoner.Inventory.Attach_Minons(minion1);
            tower.Summoner.Inventory.Attach_Minons(minion2);
            tower.Summoner.Inventory.Attach_Minons(minion3);

            tower.Boss.Inventory.Attach_Minons(BossMinion1);
            tower.Boss.Inventory.Attach_Minons(BossMinion2);
            tower.Boss.Inventory.Attach_Minons(BossMinion3);


          

        }
    }
}
