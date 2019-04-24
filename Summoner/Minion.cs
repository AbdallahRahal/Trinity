using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Minion
    {
        readonly string _name;
        // life_point
        uint _life_point;
        readonly uint _base_max_life_point;
        uint _bonus_max_life_point;
        // mana_point
        uint _mana_point;
        readonly uint _base_max_mana_point;
        uint _bonus_max_mana_point;
        // power
        readonly uint _base_power;
        uint _bonus_power;
        // dodge_rate
        readonly uint _base_dodge_rate;
        uint _bonus_dodge_rate;
        // accuracy
        readonly uint _base_accuracy;
        uint _bonus_accuracy;
        bool _is_Attach;
        Tower _context;

         readonly Armory _armories;
        

        public Minion ( string name, uint power, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy, Tower context )
        {
            _name = name;
            _life_point = _base_max_life_point = max_life_point;
            _mana_point = _base_max_mana_point = max_mana_point;
            _base_power = power;
            _base_dodge_rate = dodge_rate;
            _base_accuracy = accuracy;
            _context = context;
            _is_Attach = false;
            _armories = new Armory(this, context);
        }

        public bool is_Attach
        {
            get { return _is_Attach; }
            set { _is_Attach = value; }
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
        
        public uint Max_life_point
        {
            get { return _base_max_life_point + _bonus_max_life_point; }
        }

        public uint Bonus_max_life_point
        {
            get { return _bonus_max_life_point; }
            set { _bonus_max_life_point = value; }
        }

        public uint Power
        {
            get { return _base_power + _bonus_power; }
        }

        public uint Bonus_power
        {
            get { return _bonus_power; }
            set { _bonus_power = value; }
        }

        public uint Mana_point
        {
            get { return _mana_point; }
            set { _mana_point = value; }
        }

        public uint Max_mana_point
        {
            get { return _base_max_mana_point + _bonus_max_mana_point; }
        }

        public uint Bonus_max_mana_point
        {
            get { return _bonus_max_mana_point; }
            set { _bonus_max_mana_point = value; }
        }

        public uint Dodge_rate
        {
            get { return _base_dodge_rate + _bonus_dodge_rate; }
        }

        public uint Bonus_dodge_rate
        {
            get { return _bonus_dodge_rate; }
            set { _bonus_dodge_rate = value; }
        }

        public uint Accuracy
        {
            get { return _base_accuracy + _bonus_accuracy; }
        }

        public uint Bonus_accuracy
        {
<<<<<<< HEAD

=======
            get { return _bonus_accuracy; }
>>>>>>> 3c9ca388841d7143a8b020c7b244c381d595fa81
            set { _bonus_accuracy = value; }
        }
        
        public bool is_alive()
        {
          return (_life_point > 0) ?  true :  false;
        }

        public Armory Armories
        {
            get { return _armories; }
        }
    }
}
