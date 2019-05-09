using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Gem : Equipement
    {
        uint _ratio;
        Spell _spell;
        string _description;

        public Gem(string name, uint price, uint ratio, Spell spell, string description,string path) : base(name, price, path)
        {
            _ratio = ratio;
            _description = description;
            _spell = spell;
        }
    }
}
