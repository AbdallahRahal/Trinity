using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Summoner
    {
        readonly string _name;
        Tower _context;
        uint _money;
        readonly  Inventory _inventory;


        public Summoner(string name, Tower context)
        {
            _name = name;
            _inventory = new Inventory(context);
            _money = 100000;
        }

        public Tower Tower { get { return _context; } }

        public string Name
        {
            get { return _name; }
        }

        public Inventory Inventory
        {
            get { return _inventory;}
        }

        public uint Money
        {
            get { return _money; }
            set { _money = value; }
        }
    }
}

