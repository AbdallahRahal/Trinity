using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Weapon : Equipement
    {
        string _type;
        uint _power;

        internal Weapon(string name, string type, uint power) : base(name)
        {
            _power = power;
            _type = type;
        }

        public uint Power
        {
            get { return _power; }
        }
        public string Type
        {
            get { return _type ; }
        }
    }
}
