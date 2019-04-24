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
            Update();
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
            Update();
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
            Update();
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
            Update();
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
            Update();
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
            Update();
            return true;
        }

        public void Update()
        {
            uint _max_life_point = 0;
            uint _max_mana_point = 0;
            uint _dodge_rate = 0;
            uint _accuracy = 0;
            uint _power = 0;

            if (_hat != null) {

                Dictionary<string, uint> stats = _hat.Update();
                _max_life_point += stats["_max_life_point"];
                _max_mana_point += stats["_max_mana_point"];
                _dodge_rate += stats["_dodge_rate"];
                _accuracy += stats["_accuracy"];

            }
            if (_breastplate != null)
            {

                Dictionary<string, uint> stats = _breastplate.Update();
                _max_life_point += stats["_max_life_point"];
                _max_mana_point += stats["_max_mana_point"];
                _dodge_rate += stats["_dodge_rate"];
                _accuracy += stats["_accuracy"];

            }
            if (_leg != null)
            {

                Dictionary<string, uint> stats = _leg.Update();
                _max_life_point += stats["_max_life_point"];
                _max_mana_point += stats["_max_mana_point"];
                _dodge_rate += stats["_dodge_rate"];
                _accuracy += stats["_accuracy"];

            }
            if (_boots != null)
            {

                Dictionary<string, uint> stats = _boots.Update();
                _max_life_point += stats["_max_life_point"];
                _max_mana_point += stats["_max_mana_point"];
                _dodge_rate += stats["_dodge_rate"];
                _accuracy += stats["_accuracy"];

            }
            if (_weapon != null)
            {

                _power += _weapon.Update();

            }

            _minion.Bonus_max_life_point = _max_life_point;
            _minion.Bonus_max_mana_point = _max_mana_point;
            _minion.Bonus_dodge_rate = _dodge_rate;
            _minion.Bonus_accuracy = _accuracy;
            _minion.Bonus_power = _power;

        }

        


            public bool Desequip(string name)
        {
           
            if (_equipements.ContainsKey(name))
            {

                _equipements[name].Is_Equiped = false;
                _equipements.Remove(name);
                if (_hat != null && name == _hat.Name) { _hat = null; }
                else
                if (_breastplate != null && name == _breastplate.Name) { _breastplate = null; }
                else
                if (_leg != null &&  name == _leg.Name) { _leg = null; }
                else
                if (_boots != null && name == _boots.Name) { _boots = null; }
                else
                if (_weapon != null && name == _weapon.Name) { _weapon = null; }
                else
                if (_gem1 != null && name == _gem1.Name) { _gem1 = null; }
                else
                if (_gem2 != null && name == _gem2.Name) { _gem2 = null; }
                else
                if (_gem3 != null && name == _gem3.Name ){ _gem3 = null; }


                return true;
            }
            else
            {
                throw new ArgumentException("L'objet n'est pas équipé ");
            }
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