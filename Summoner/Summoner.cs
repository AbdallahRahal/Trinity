using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Summoner
    {
        readonly string _name;
        readonly Dictionary<string, Inventory> _inventory;


        internal Summoner(string name)
        {
            _name = name;
           
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
