using System.Collections.Generic;

namespace Trinity
{
    public class Equipement_Nospell : Equipement
    {
        readonly uint _max_life_point;
        readonly uint _max_mana_point;
        readonly uint _dodge_rate;
        readonly uint _accuracy;
        readonly uint _lead;

        public Equipement_Nospell(string name, uint price, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy, uint lead,string path) : base(name, price, path)
        {
            _max_life_point = max_life_point;
            _max_mana_point = max_mana_point;
            _dodge_rate = dodge_rate;
            _accuracy = accuracy;
            _lead = lead;
        }

        public uint Max_life_point
        {
            get { return _max_life_point; }
        }

        public uint Max_mana_point
        {
            get { return _max_mana_point; }
        }

        public uint Dodge_rate
        {
            get { return _dodge_rate; }
        }

        public uint Accuracy
        {
            get { return _accuracy; }
        }
        public uint Lead
        {
            get { return _lead; }
        }


        public Dictionary<string,uint> Update()
        {
            Dictionary<string, uint> stats = new Dictionary<string, uint>();
            stats.Add("_max_life_point", _max_life_point);
            stats.Add("_max_mana_point", _max_mana_point);
            stats.Add("_dodge_rate", _dodge_rate);
            stats.Add("_accuracy", _accuracy);
            return stats;
        }
    }
}