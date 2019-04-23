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
    class UnitTests_Summoner
    {
        [Test]
        public void Create_Summoner()
        {
            Tower tower = new Tower() ;
            Summoner summoner = tower.Create_Summoner("karo");
            Assert.That(summoner.Name, Is.EqualTo("karo"));
        }

        /* [Test]
         public void attach_Two_Minions() { }
         {
             Tower tower = new Tower();
             Summoner sum = tower.Create_Summoner("karo");
             Minion m1 = tower.Minion_Collection.Create_Minion("Ryan", 10, 10, 10, 10, 10);
             Minion m2 = tower.Minion_Collection.Create_Minion("Ker", 11, 11, 11, 11, 11);




         }*/

        [Test]
        public void Try_New_direction() { }

     
       
    }
}
