//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;


//namespace Trinity.UnitTests
//{
//    [TestFixture]
//    class UnitTests_Inventory
//    {
//        [Test]
//        public void attach_minion()
//        {
//            Tower tower = new Tower();
//            Minion m1 = tower.Minion_Collection.Create_Minion("Ryaan", 50, 23, 65, 0, 20, 20, "../../../MinionSprites/Morgan.png");
//            Minion m2 = tower.Minion_Collection.Create_Minion("ker", 50, 23, 65, 0, 20, 20, "../../../MinionSprites/Morgan.png");
//            Summoner sum = new Summoner("roko", tower);

//            var a = sum.Inventory.Attach_Minons(m1);
//            var b = sum.Inventory.Attach_Minons(m2);
//            var c = sum.Inventory.Attach_Minons(m1);

//            Assert.That(a, Is.EqualTo(true));
//            Assert.That(b, Is.EqualTo(true));
//            Assert.That(c, Is.EqualTo(false));

//        }
//    }
//}
