using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Trinity.UnitTests
{
    [TestFixture]
    class UnitTests_Minion
    {
        //[Test]
        //public void Create_Equip_Equipement()
        //{
        //    Tower tow = new Tower();
        //    Minion m1 = tow.Minion_Collection.Create_Minion("Ryan", 10, 10, 10, 10, 10);
        //    //Weapon arc = tow.Equipement_Collection.Create_Weapon("Arc de Ryan", 50);
        //    //Hat chapeau = tow.Equipement_Collection.Create_Hat("Cheapeu de sorcier", 10, 10, 10, 10);
        //    //Leg pant = tow.Equipement_Collection.Create_Leg("Pantalon", 10, 10, 10, 10);
        //    //m1.Armories.Equip(arc);

        //    m1.Armories.Equip(chapeau);
        //    m1.Armories.Equip(pant);

        //    Assert.That(m1.Name, Is.EqualTo("Ryan"));
        //    Assert.That(arc.Name, Is.EqualTo("Arc de Ryan"));
        //    Assert.That(arc.Power, Is.EqualTo(50));
        //    Assert.That(m1.Armories.Weapon, Is.EqualTo(arc));
        //    Assert.That(m1.Armories.Hat, Is.EqualTo(chapeau));
        //    Assert.That(m1.Armories.Leg.Name, Is.EqualTo("Pantalon"));

        //    Assert.That(pant.Is_Equiped, Is.True);
        //    //  le pantalon est equipé

        //    m1.Armories.Desequip("Pantalon");


        //    Assert.That(m1.Armories.Leg, Is.Null);
        //    Assert.That(pant.Is_Equiped, Is.False);

        //}

        //[Test]
        //public void Equip_equipement_calcul_bonus()
        //{
        //    Tower tow = new Tower();
        //    Minion minion = tow.Minion_Collection.Create_Minion("Ryan", 10, 10, 10, 10, 10);
        //    Weapon arc = tow.Equipement_Collection.Create_Weapon("Arc de Ryan", 50);
        //    Hat chapeau = tow.Equipement_Collection.Create_Hat("Cheapeu de sorcier", 10, 0, 7, 0);
        //    Leg pant = tow.Equipement_Collection.Create_Leg("Pantalon", 10, 10, 7, 0);
        //    minion.Armories.Equip(arc);
        //    minion.Armories.Equip(chapeau);
        //    minion.Armories.Equip(pant);
        //    //test des updat() des bonus
        //    Assert.That(minion.Bonus_power, Is.EqualTo(50));
        //    Assert.That(minion.Bonus_max_life_point, Is.EqualTo(20));
        //    Assert.That(minion.Bonus_max_mana_point, Is.EqualTo(10));
        //    Assert.That(minion.Bonus_dodge_rate, Is.EqualTo(14));
        //    Assert.That(minion.Bonus_accuracy, Is.EqualTo(0));

        //    //test bonus + stats de base
        //    Assert.That(minion.Power, Is.EqualTo(60));
        //    Assert.That(minion.Accuracy, Is.EqualTo(10));


        //}
    }
}