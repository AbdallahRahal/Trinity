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
            Tower tower = new Tower;
            Summoner summoner = tower.CreateSummoner("karo");
            Assert.That(summoner.Name, Is.EqualTo("karo"));
        }

        [Test]
        public void Try_New_direction() { }

        [Test]
        public void 
    }
}
