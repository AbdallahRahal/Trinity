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
       Tower _context;
        public Equipement_Collection(Tower tower)
        {
            _context = tower;
            _equipements = new Dictionary<string, Equipement>();
        }

        public Hat Create_Hat(string name , uint price, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy,uint lead, string path)
        {
           
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Hat hat = new Hat(name, price, max_life_point, max_mana_point, dodge_rate,lead, accuracy,path);

            _equipements.Add(name, hat);
            return hat;
        }
        public Breastplate Create_Breastplate(string name, uint price, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy, uint lead, string path)
        {

            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Breastplate breastplate = new Breastplate(name, price, max_life_point, max_mana_point, dodge_rate, lead, accuracy, path);

            _equipements.Add(name, breastplate);
            return breastplate;
        }


        public Leg Create_Leg(string name, uint price, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy, uint lead, string path)
        {

            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Leg leg = new Leg(name, price, max_life_point, max_mana_point, dodge_rate, lead, accuracy, path);

            _equipements.Add(name, leg);
            return leg;
        }


        public Boots Create_Boots(string name, uint price, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy, uint lead, string path)
        {

            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements  with this name already exists.", nameof(name));

            Boots boots = new Boots(name, price, max_life_point, max_mana_point, dodge_rate, lead, accuracy, path);

            _equipements.Add(name, boots);
            return boots;
        }

        public Weapon Create_Weapon(string name,  uint price, uint power,string path)
        {
            //type = type de l'arme, arc, baton , epée ...
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements with this name already exists.", nameof(name));
            Weapon weapon = new Weapon(name, price, power, path);

            _equipements.Add(name, weapon);
            return weapon;
        }

        public Gem Create_Gem(string name, uint price, string path)
        {
            if (_equipements.ContainsKey(name)) throw new ArgumentException("An equipements with this name already exists.", nameof(name));
            if (_context.Spell.join(name)) {
                Gem gem = new Gem(name, price, path);

                _equipements.Add(name, gem);
                return gem;

            } else {
                return null;
            }
            
        }

        public Dictionary<string, Equipement> Equipement_Dictionnary
        {
            get { return _equipements; }
        }



    }
}
