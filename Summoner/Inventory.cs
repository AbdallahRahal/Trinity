using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Inventory
    {
        readonly Dictionary<string, Minion> _minions;
        readonly Dictionary<string, Equipement> _equipements;

        Summoner summoner;

        internal Inventory()
        {
            _minions = new Dictionary<string, Minion>();
            _equipements = new Dictionary<string, Equipement>();
        }

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

        /// <summary>
        ///add a minion from a inventory 
        /// </summary>
        /// <param name="minion"></param>
        /*public void  
        {
            
        }*/

        /// <summary>
        ///Remove a minion from a inventory 
        /// </summary>
        /// <param name="minion"></param>
        public void RemoveMinion(Minion m)
        {
            if (_minions.TryGetValue(m.Name, out m)) _minions.Remove(m.Name);
        }
    }
}
