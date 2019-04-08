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


        internal Armory(Minion minion)
        {
            _minion = minion;
        }

        internal Minion Minion { get { return _minion; } }

    }
}
