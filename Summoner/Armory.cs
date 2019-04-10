using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    class Armory
    {
        Minion _minion;
        Hat hat;
        Breastplate Breastplate;
        Leg leg;
        Boots boots;
        Gem gem1;
        Gem gem2;
        Gem gem3;


        internal Armory(Minion minion)
        {
            _minion = minion;
        }

        internal Minion Minion { get { return _minion; } }

    }
}
