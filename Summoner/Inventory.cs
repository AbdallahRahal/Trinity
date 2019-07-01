using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Inventory
    {
        readonly Dictionary<string, Minion> _minions;
        readonly Dictionary<string, Equipement> _equipements;
        Minion _minion1;
        Minion _minion2;
        Minion _minion3;
        Tower _context;
        public Summoner _summoner;

        public Inventory(Tower context,Summoner sum)
        {
            _minions = new Dictionary<string, Minion>();
            _equipements = new Dictionary<string, Equipement>();
            _context = context;
            _summoner = sum;
        }
        public List<Minion> Allminion()
        {
            List<Minion> allminion = new List<Minion>();
            allminion.Add(Minion1);
            allminion.Add(Minion2);
            allminion.Add(Minion3);
            return allminion;
        }

        public Dictionary<string, Equipement> Equipement
        {
            get { return _equipements; }
        }
        public Dictionary<string, Minion> minionItem
        {
            get { return _minions; }
        }

        public Tower Tower { get { return _context; } }

        /// <summary>
        /// Find Minion by it name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Minion FindMinionByName(string name)
        {
            Minion result;
            _minions.TryGetValue(name, out result);
            return result;
        }
        public bool ContainMinion(Minion minion)
        {
            if (Minion1 == minion || Minion2 == minion || Minion3 == minion ) return true;

            return false;
        }
        public void AddEquip(Equipement equip)
        {
            _equipements.Add(equip.Name, equip);
           
        }
        public void RemovEquip(Equipement equip)
        {
            if (_equipements.TryGetValue(equip.Name, out equip)) { _equipements.Remove(equip.Name);}
        }
        /// <summary>
        ///Remove a minion from a inventory 
        /// </summary>
        /// <param name="minion"></param>
        public void RemoveMinion(Minion m)
        {
            if (_minions.TryGetValue(m.Name, out m)) { _minions.Remove(m.Name); m.is_Attach = false; }
        }

        /// <summary>
        ///add a minion from a inventory 
        /// </summary>
        /// <param name="minion"></param>
        public bool Attach_Minons(Minion minion)
        {
            if ( _context.Minion_Collection.Minion_Dictionnary.ContainsKey(minion.Name) && minion.is_Attach == false)
            {
               

                if (_minion1 == null)
                {
                    _minion1 = minion;
                    _minions.Add(minion.Name, minion);
                    minion.is_Attach = true;
                    minion._summoner = this._summoner;
                }
               else if (_minion2 == null)
                {
                    _minion2 = minion;
                    _minions.Add(minion.Name, minion);
                    minion.is_Attach = true;
                    minion._summoner = this._summoner;
                }
                else if (_minion3 == null)
                {
                    _minion3 = minion;
                    _minions.Add(minion.Name, minion);
                    minion.is_Attach = true;
                    minion._summoner = this._summoner;
                }
                else
                {
                    throw new ArgumentException("les minions sont deja attachés");
                }
                return true;
            }
            return false;
        }

        public Minion Minion1
        {
            get { return _minion1; }
        }

        public Minion Minion2
        {
            get { return _minion2; }
        }

        public Minion Minion3
        {
            get { return _minion3; }
        }
        
        public void Update()
        {
            if (_minion1 != null) Minion1.Armories.Update();
            if (_minion2 != null) Minion2.Armories.Update();
            if (_minion3 != null) Minion3.Armories.Update();

        }
    }
}
