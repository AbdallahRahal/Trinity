﻿namespace Trinity
{
    internal class Equipement_Nospell : Equipement
    {
        readonly uint _max_life_point;
        readonly uint _max_mana_point;
        readonly uint _dodge_rate;
        readonly uint _accuracy;

        internal Equipement_Nospell(string name, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy) : base(name)
        {
            _max_life_point = max_life_point;
            _max_mana_point = max_mana_point;
            _dodge_rate = dodge_rate;
            _accuracy = accuracy;
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
    }
}