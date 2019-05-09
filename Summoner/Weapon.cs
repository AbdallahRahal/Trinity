using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Weapon : Equipement
    {
       
        uint _power;

        public Weapon(string name, uint price, uint power,string path) : base(name, price, path)
        {
            _power = power;
         
        }

        public uint Power
        {
            get { return _power; }
        }
       
        public uint Update()
        {
            return _power;
        }
    }
}
