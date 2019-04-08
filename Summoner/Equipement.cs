using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public abstract class Equipement
    {
        readonly string _name;
        uint ratio;

        Inventory inventory;

        internal Equipement(string name)
        {

            _name = name;
        }

    }
}
