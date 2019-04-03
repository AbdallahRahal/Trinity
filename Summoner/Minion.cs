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
        uint _ratio;

        Weapon weapon;
        Hat hat;
        Helmet helmet;
        Legging legging;
        Boot boot;


        public string Name
        {
            get { return _name; }
        }

        public uint Life_point
        {
            get { return _life_point; }
            set { _life_point = value; }
        }
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
        public uint Ratio
        {
            get { return _ratio; }
            set { _ratio = value; }
        }
    }
}
