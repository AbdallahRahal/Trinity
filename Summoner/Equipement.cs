using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public abstract class Equipement
    {
        readonly string _name;
        uint ratio;
        bool is_Equiped;

        Inventory inventory;

        public Equipement(string name)
        {
            _name = name;
            is_Equiped = false;

        }
        public bool Is_Equiped
        {
            get { return is_Equiped; }
            set { is_Equiped = value; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
