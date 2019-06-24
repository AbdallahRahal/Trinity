using System;
using System.Collections.Generic;

namespace Trinity
{
    public class Tower
    {
        readonly Equipement_Collection _equipement;
        readonly Minion_Collection _minion;
        readonly Store _store;
        readonly Summoner _summoner;
        readonly Summoner _boss;
        readonly Spell _spell;
        readonly Weaponry _weaponry;

        public Tower()
        {
            _equipement = new Equipement_Collection(this);
            _minion = new Minion_Collection(this);
            _store = new Store(this);
            _summoner = new Summoner("Joueur", this);
            _boss = new Summoner("Boss", this);
            _weaponry = new Weaponry(this);
            _spell = new Spell(this);
        }


        public Equipement_Collection Equipement_Collection
        {
            get { return _equipement; }
        }

        public Minion_Collection Minion_Collection
        {
            get { return _minion; }
        }

        public Summoner Summoner
        {
            get { return _summoner; }
        }
        public Summoner Boss
        {
            get { return _boss; }
        }

        public Spell Spell
        {
            get { return _spell; }
        }
        public Store Store
        {
            get { return _store; }
        }

        public Weaponry Weaponry
        {
            get { return _weaponry; }
        }

        public Summoner Create_Summoner(string name)
        {
            //if (_minions.ContainsKey(name)) throw new ArgumentException("A minion with this name already exists.", nameof(name));
            Summoner summoner = new Summoner(name, this);
          
            return summoner;
        }
    }
}
