using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Minion
    {
        readonly string _name;
        uint _life_point;
        uint _max_life_point;
        uint _power;
        uint _mana_point;
        uint _max_mana_point;
        uint _dodge_rate;
        uint _accuracy;

        readonly Armory _armories;
        Minion_inventory minion_inventory;
        Weapon weapon;
        Hat hat;
        Helmet helmet;
        Legging legging;
        Boot boot;

        internal Minion ( string name, uint power, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy )
        {
            _name = name;
            _life_point = _max_life_point = max_life_point;
            _mana_point = _max_mana_point = max_mana_point;
            _power = power;
            _dodge_rate = dodge_rate;
            _accuracy = accuracy;
            _armories = new Armory(this);
        }

        public string Name
        {
            get { return _name; }
        }

        public uint Life_point
        {
            get { return _life_point; }
            set { _life_point = value; }
        }
        nm
        public uint Max_life_point
        {
            get { return _max_life_point; }
            set { _max_life_point = value; }
        }

        public uint Power
        {
            get { return _power; }
            set { _power = value; }
        }

        public uint Mana_point
        {
            get { return _mana_point; }
            set { _mana_point = value; }
        }

        public uint Max_mana_point
        {
            get { return _max_mana_point; }
            set { _max_mana_point = value; }
        }

        public uint Dodge_rate
        {
            get { return _dodge_rate; }
            set { _dodge_rate = value; }
        }

        public uint Accuracy
        {
            get { return _accuracy; }
            set { _accuracy = value; }
        }
        

        public bool is_alive()
        {
          return (_life_point > 0) ?  true :  false;
        }

        internal Armory Armories
        {
            get { return _armories; }
        }
    }
}
