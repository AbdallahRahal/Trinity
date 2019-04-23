using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Trinity.UnitTests
{
    [TestFixture]
    class UnitTests_Inventory
    {
        [Test]
        public void attach_minion()
        {
            Tower tower = new Tower();
            Minion m1 = tower.Minion_Collection.Create_Minion("Ryan", 10, 10, 10, 10, 10);
            Minion m2 = tower.Minion_Collection.Create_Minion("Ker", 10, 10, 10, 10, 10);
            Summoner sum = new Summoner("roko", tower);

            var a = sum.Inventory.Attach_Minons(m1);
            var b = sum.Inventory.Attach_Minons(m2);
            var c = sum.Inventory.Attach_Minons(m1);

            Assert.That(a, Is.EqualTo(true));
            Assert.That(b, Is.EqualTo(true));
            Assert.That(c, Is.EqualTo(false));

        }
    }
}
