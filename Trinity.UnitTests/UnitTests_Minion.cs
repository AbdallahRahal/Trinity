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
        [Test]
        public void Create_Equipement()
        {
            Tower tow = new Tower();
            Minion m1 = tow.Minion_Collection.Create_Minion("Ryan", 10, 10, 10, 10, 10);
            Weapon arc = tow.Equipement_Collection.Create_Weapon("Arc de Ryan", 50);
            Hat chapeau = tow.Equipement_Collection.Create_Hat("Cheapeu de sorcier",10,10,10,10);
            Leg pant = tow.Equipement_Collection.Create_Leg("Pantalon", 10, 10, 10, 10);
            m1.Armories.Equip(arc);
            m1.Armories.Equip(chapeau);

            Assert.That(m1.Name, Is.EqualTo("Ryan"));
            Assert.That(arc.Name, Is.EqualTo("Arc de Ryan"));
            Assert.That(arc.Power, Is.EqualTo(50));
            Assert.That(m1.Armories.Weapon, Is.EqualTo(arc));
            Assert.That(m1.Armories.Hat, Is.EqualTo(chapeau));
           // Assert.That(m1.Armories.Leg.name, Is.EqualTo("Pantalon"));
        }
    }
}
