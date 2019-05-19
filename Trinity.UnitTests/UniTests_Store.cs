using Trinity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Trinity.UnitTests
{
    [TestFixture]
    class UnitTests_Store
    {
        [Test]
        public void Buy_equip()
        {
            Tower tow = new Tower();
            Summoner sum = tow.Summoner;
            //Inventory invent = new Inventory(tow);

            Weapon arc = tow.Equipement_Collection.Create_Weapon("pistolet", 50, 50, "de");
            Hat chapeau = tow.Equipement_Collection.Create_Hat("grand", 10, 10, 10, 10, 10, 10, "dee");
            Leg pant = tow.Equipement_Collection.Create_Leg("Cheapeu sorcier", 10, 10, 10, 10, 10, 20, "deeee");
            Weapon arcc = tow.Equipement_Collection.Create_Weapon("Arc", 10, 50, "Sprites/arc.png");
            Weapon epee = tow.Equipement_Collection.Create_Weapon("de Ryan", 1, 50, "arcqb.png");
            Hat bob = tow.Equipement_Collection.Create_Hat("bob", 50, 10, 20, 2, 4, 30, "Sprites/bob.jpg");
            Boots lv = tow.Equipement_Collection.Create_Boots("lvuitton", 10, 10, 10, 10, 10, 10, "katana.jpg");
            Boots nike = tow.Equipement_Collection.Create_Boots("nikeair", 10, 10, 10, 10, 10, 10, "nike.jpg");
            Hat carre = tow.Equipement_Collection.Create_Hat("Carré", 10, 10, 10, 10, 10, 10, "carre");
            Breastplate ocho = tow.Equipement_Collection.Create_Breastplate("quavohuncho", 10, 10, 10, 10, 10, 10, "huncho.boohoo");
            Boots adidas = tow.Equipement_Collection.Create_Boots("adidasyeezy", 10, 10, 10, 10, 10, 10, "adidas.ocho");
            Hat bonnet = tow.Equipement_Collection.Create_Hat("bonnet", 10, 10, 10, 10, 10, 10, "bonnet");
            Breastplate nwar = tow.Equipement_Collection.Create_Breastplate("nwarrpirate", 10, 10, 10, 10, 10, 10, "nwarr.izisaal");

            //Minion minion1 = tow.Minion_Collection.Create_Minion("Morgan", 100, 100, 100, 20, 20, 5, "../../../MinionSprites/Morgan.png");
            //Minion minion2 = tow.Minion_Collection.Create_Minion("Ryaan", 50, 23, 65, 0, 20, 20,  "../../../MinionSprites/Morgan.png");
            //Minion minion3 = tow.Minion_Collection.Create_Minion("Abdel", 50, 23, 65, 0, 20, 70,"../../../MinionSprites/Morgan.png");

            tow.Store.Aviable();
            int count = tow.Store.Aviable_Equipement.Count;

            tow.Store.Buy_Equip(epee);
            var a = sum.Inventory.Equipement.ContainsValue(epee);

            tow.Store.Buy_Equip(nike);
            var b = sum.Inventory.Equipement.ContainsValue(nike);

            var c = sum.Inventory.Equipement.Count;

            Assert.That(count, Is.EqualTo(9));
            Assert.That(a, Is.EqualTo(true));
            Assert.That(b, Is.EqualTo(true));
            Assert.That(c, Is.EqualTo(2));


            //sum.Inventory.AddEquip(arc);
            //tow.Summoner.Inventory.AddEquip(chapeau);
            //tow.Summoner.Inventory.AddEquip(pant);



        }




    }
}
