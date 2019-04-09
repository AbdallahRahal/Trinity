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
    class UnitTests_Equipement
    {
        [Test]
        public void Create_Equipement()
        {
            Tower tower = new Tower();
            Weapon arc1 = tower.Equipement.Create_Equipement("equip1", "arc", 15);

            Assert.That(arc1.Name, Is.EqualTo("equip1"));
        }

      


    }
}
