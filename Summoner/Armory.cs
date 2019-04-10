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
        Hat hat;
        Breastplate breastplate;
        Leg leg;
        Boots boots;
        Gem gem1;
        Gem gem2;
        Gem gem3;
        Weapon weapon;
        Dictionary<string, Equipement> _equipements = new Dictionary<string, Equipement>();
        Tower _context;


        public Armory(Minion minion, Tower context)
        {
            _minion = minion;
            _context = context;
        }

        public Minion Minion { get { return _minion; } }
        public Tower Tower { get { return _context; } }


        public bool Equip(Equipement equip)
        {


            if (_context.Equipement_Collection.Equipement_Dictionnary.ContainsKey(equip.Name) && equip.Is_Equiped == false)
            {
                equip.Is_Equiped = true;


                if (equip.GetType().IsInstanceOfType(hat) && hat == null)
                {
                    hat = (Hat)equip;
                    _equipements.Add(equip.Name, equip);
                }
                else if (equip.GetType().IsInstanceOfType(breastplate) && breastplate == null)
                {
                    breastplate = (Breastplate)equip;
                    _equipements.Add(equip.Name, equip);
                }
                else if (equip.GetType().IsInstanceOfType(leg) && leg == null)
                {
                    leg = (Leg)equip;
                    _equipements.Add(equip.Name, equip);
                }
                else if (equip.GetType().IsInstanceOfType(boots) && boots == null)
                {
                    boots = (Boots)equip;
                    _equipements.Add(equip.Name, equip);
                }
                else if (equip.GetType().IsInstanceOfType(weapon) && weapon == null)
                {
                    weapon = (Weapon)equip;
                    _equipements.Add(equip.Name, equip);
                }
                else if (equip.GetType().IsInstanceOfType(gem1))
                {
                    if (gem1 == null) { gem1 = (Gem)equip; _equipements.Add(equip.Name, equip); }
                    else if (gem2 == null) { gem2 = (Gem)equip; _equipements.Add(equip.Name, equip); }
                    else if (gem3 == null) { gem3 = (Gem)equip; _equipements.Add(equip.Name, equip); }
                }
                else
                {
                    throw new ArgumentException("Un objet est deja equipé, ou le type de l'equipement n'est pas un : Hat,breastplate,leg,boots,weapon ou gem  ");
                }

                return true;
            }

            return false;
        }


        public bool Desequip(string name)
        {
            Equipement equip;
            if (_equipements.TryGetValue(name, out equip))
            {
                equip.Is_Equiped = false;

                if (name == hat.Name) { hat = null; }


                return true;
            }
            return false;
        }

        public Hat Hat
        {
            get { return hat; }
        }

        public Breastplate Breastplate
        {
            get { return breastplate; }
        }

        public Leg Leg
        {
            get { return leg; }
        }

        public Boots Boots
        {
            get { return boots; }
        }

        public Gem Gem1
        {
            get { return gem1; }
        }

        public Gem Gem2
        {
            get { return gem2; }
        }

        public Gem Gem3
        {
            get { return gem3; }
        }
    }
}