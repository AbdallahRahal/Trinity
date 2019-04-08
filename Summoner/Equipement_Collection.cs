using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    class Equipement_Collection
    {
        readonly Dictionary<string, Equipement> _equipements;

        internal Equipement_Collection()
        {

            _equipements = new Dictionary<string, Equipement>();
        }

        public Equipement Create_Equipement(string name , string type, Dictionary<string,int> stats )
        {

            Armor armor = new Armor(name,type,stats);

            _equipements.Add(name, armor);
            return armor;
        }

        public Equipement Create_Equipement(string name, string type, uint power)
        {

            Weapon weapon = new Weapon(name, type, power);

            _equipements.Add(name, weapon);
            return weapon;
        }

        public Equipement Create_Equipement(string name, uint ratio, Spell spell, string description)
        {

            Gem gem = new Gem(name, ratio, spell, description);

            _equipements.Add(name, gem);
            return gem;
        }




    }
}
