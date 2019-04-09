using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Equipement_Collection
    {
        readonly Dictionary<string, Equipement> _equipements;

        internal Equipement_Collection()
        {

            _equipements = new Dictionary<string, Equipement>();
        }

        public Armor Create_Equipement(string name , string type, Dictionary<string,int> stats )
        {
            //type = type de la piece d'armure , chapeau,plastron, jambiere, botte
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));
            Armor armor = new Armor(name,type,stats);

            _equipements.Add(name, armor);
            return armor;
        }

        public Weapon Create_Equipement(string name, string type, uint power)
        {
            //type = type de l'arme, arc, baton , epée ...
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements with this name already exists.", nameof(name));
            Weapon weapon = new Weapon(name, type, power);

            _equipements.Add(name, weapon);
            return weapon;
        }

        public Gem Create_Equipement(string name, uint ratio, Spell spell, string description)
        {
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements with this name already exists.", nameof(name));
            Gem gem = new Gem(name, ratio, spell, description);

            _equipements.Add(name, gem);
            return gem;
        }




    }
}
