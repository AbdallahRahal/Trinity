using System;
using System.Collections.Generic;

namespace Trinity
{
    public class Tower
    {
        readonly Equipement_Collection _equipement;
        readonly Minion_Collection _minion;

        public Tower()
        {
            _equipement = new Equipement_Collection();
            _minion = new Minion_Collection();
        }


        public Equipement_Collection Equipement
        {
            get { return _equipement; }
        }

        public Minion_Collection Minion
        {
            get { return _minion; }
        }
    }
}
