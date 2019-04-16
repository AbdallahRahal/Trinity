using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Armory
    {
        Minion _minion;
        Hat _hat;
        Breastplate _breastplate;
        Leg _leg;
        Boots _boots;
        Gem _gem1;
        Gem _gem2;
        Gem _gem3;
        Weapon _weapon;
        Dictionary<string, Equipement> _equipements = new Dictionary<string, Equipement>();
        Tower _context;


        public Armory(Minion minion, Tower context)
        {
            _minion = minion;
            _context = context;
            _weapon = null;
        }

        public Minion Minion { get { return _minion; } }
        public Tower Tower { get { return _context; } }


        public bool Equip(Weapon weapon)
        {
            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(weapon.Name) && weapon.Is_Equiped == false && _weapon == null)
            {
                weapon.Is_Equiped = true;
                _weapon = weapon;
                    _equipements.Add(weapon.Name, weapon);

            }
            else
            {
                throw new ArgumentException("Un objet est deja equipé ");
            }
            return true;
        }

        public bool Equip(Hat hat)
        {
            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(hat.Name) && hat.Is_Equiped == false && _hat == null)
            {
                hat.Is_Equiped = true;
                _hat = hat;
                _equipements.Add(hat.Name, hat);

            }
            else
            {
                throw new ArgumentException("Un objet est deja equipé ");
            }
            return true;
        }
        public bool Equip(Breastplate breastplate)
        {
            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(breastplate.Name) && breastplate.Is_Equiped == false && _breastplate == null)
            {
                breastplate.Is_Equiped = true;
                _breastplate = breastplate;
                _equipements.Add(breastplate.Name, breastplate);

            }
            else
            {
                throw new ArgumentException("Un objet est deja equipé ");
            }
            return true;
        }


        public bool Equip(Leg leg)
        {
            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(leg.Name) && leg.Is_Equiped == false && _leg == null)
            {
                leg.Is_Equiped = true;
                _leg = leg;
                _equipements.Add(leg.Name, leg);

            }
            else
            {
                throw new ArgumentException("Un objet est deja equipé ");
            }
            return true;
        }

        public bool Equip(Boots boots)
        {
            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(boots.Name) && boots.Is_Equiped == false && _boots == null)
            {
                boots.Is_Equiped = true;
                _boots = boots;
                _equipements.Add(boots.Name, boots);

            }
            else
            {
                throw new ArgumentException("Un objet est deja equipé ");
            }
            return true;
        }
        public bool Equip(Gem gem)
        {
            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(gem.Name) && gem.Is_Equiped == false)
            {
                
                if (_gem1 == null) { gem.Is_Equiped = true; _gem1 = gem; _equipements.Add(gem.Name, gem); }
                else if (_gem2 == null) { gem.Is_Equiped = true; _gem2 = gem; _equipements.Add(gem.Name, gem); }
                else if (_gem3 == null) { gem.Is_Equiped = true; _gem3 = gem; _equipements.Add(gem.Name, gem); }
            }
            else
            {
                throw new ArgumentException("Un objet est deja equipé ");
            }
            return true;
        }

        public bool Desequip(string name)
        {
            Equipement equip = null;
            if (_equipements.ContainsKey(name))
            {
                equip.Is_Equiped = false;
                _equipements.Remove(name);
                if (name == _hat.Name) { _hat = null;}else
                if (name == _breastplate.Name) { _breastplate = null;}else
                if (name == _leg.Name) { _leg = null;}else
                if (name == _boots.Name) { _boots = null;}else
                if (name == _weapon.Name) { _weapon = null;}else
                if (name == _gem1.Name) { _gem1 = null;}else
                if (name == _gem2.Name) { _gem2 = null;}else
                if (name == _gem3.Name) { _gem3 = null;}


                return true;
            }
            return false;
        }

        public Hat Hat
        {
            get { return _hat; }
        }

        public Breastplate Breastplate
        {
            get { return _breastplate; }
        }

        public Leg Leg
        {
            get { return _leg; }
        }

        public Boots Boots
        {
            get { return _boots; }
        }

        public Gem Gem1
        {
            get { return _gem1; }
        }

        public Gem Gem2
        {
            get { return _gem2; }
        }

        public Gem Gem3
        {
            get { return _gem3; }
        }

        public Weapon Weapon
        {
            get { return _weapon; }
        }
    }
}