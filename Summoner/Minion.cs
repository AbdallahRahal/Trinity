using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Minion
    {
        readonly string _name;
        string _path;
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
        // lead
        readonly uint _base_lead;
        uint _bonus_lead;
        // accuracy
        readonly uint _base_accuracy;
        uint _bonus_accuracy;
        bool _is_Attach;
        Tower _context;

         readonly Armory _armories;
        

        public Minion ( string name, uint power, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy,uint lead, string path, Tower context )
        {
            _name = name;
            _path = path;
            _life_point = _base_max_life_point = max_life_point;
            _mana_point = _base_max_mana_point = max_mana_point;
            _base_power = power;
            _base_dodge_rate = dodge_rate;
            _base_lead = lead;
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
        //
        public uint Lead
        {
            get { return _base_lead + _bonus_lead; }
        }

        public uint Bonus_lead
        {
            get { return _bonus_lead; }
            set { _bonus_lead = value; }
        }
        public uint Accuracy
        {
            get { return _base_accuracy + _bonus_accuracy; }
        }

        public uint Bonus_accuracy
        {
            get { return _bonus_accuracy; }
            set { _bonus_accuracy = value; }
        }
        
        public bool is_alive()
        {
          return (_life_point > 0) ?  true :  false;
        }
        public string Path
        {
            get { return _path; }
        }
        public Armory Armories
        {
            get { return _armories; }
        }

        public virtual List<string> Stats()
        {

            List<string> stats = new List<string>();
            stats.Add(String.Concat(" ", this.Name));

            stats.Add(String.Concat("Vie : ", this.Max_life_point," (",this._base_max_life_point," + ",this.Bonus_max_life_point,") "     ));
            stats.Add(String.Concat("Mana : ", this.Max_mana_point, " (", this._base_max_mana_point, " + ", this.Bonus_max_mana_point, ") "));
            stats.Add(String.Concat("Pouvoir : ", this.Power, " (", this._base_power, " + ", this.Bonus_power, ") "));
            stats.Add(String.Concat("Esquive : ", this.Dodge_rate, " (", this._base_dodge_rate, " + ", this.Bonus_dodge_rate, ") "));
            stats.Add(String.Concat("Précision : ", this.Accuracy, " (", this._base_accuracy, " + ", this.Bonus_accuracy, ") "));
            stats.Add(String.Concat("Initiative : ", this.Lead, " (", this._base_lead, " + ", this.Bonus_lead, ") "));

            return stats;
        }
    }
}
