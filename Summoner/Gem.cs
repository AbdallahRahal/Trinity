using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    class Gem : Equipement
    {
        uint _ratio;
        Spell _spell;
        string _description;

        internal Gem(string name, uint ratio, Spell spell, string description) : base(name)
        {
            _ratio = ratio;
            _description = description;
            _spell = spell
        }
    }
}
