using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Minion_Collection
    {
        Dictionary<string, Minion> _minions;

        internal Minion_Collection()
        {
            _minions = new Dictionary<string, Minion>();
        }


        /// <summary>
        /// Creates a new minion in this collection.
        /// </summary>
        /// <param name="name">name of the new minion. This name must be unique otherwise an <see cref="ArgumentException"/> is thrown.</param>
        /// <returns>The newly created minion.</returns>
        internal Minion CreateMinion(string name, uint power, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy)
        {
            if (_minions.ContainsKey(name)) throw new ArgumentException("A minion with this name already exists.", nameof(name));
            Minion minion = new Minion(name, power, max_life_point, max_mana_point, dodge_rate, accuracy);
            _minions.Add(name, minion);
            return minion;
        }

        internal Minion FindByName( string name)
        {
            Minion minion;
            _minions.TryGetValue(name, out minion);
            return minion;
        }

        internal void RemoveMinion ( Minion minion)
        {
            _minions.Remove(minion.Name);
        }

        internal void OnRename( Minion minion, string newName)
        {
            if (_minions.ContainsKey(newName)) throw new ArgumentException(" A minion with this name already exists.", nameof(newName));
            _minions.Remove(minion.Name);
            _minions.Add(newName, minion);
        }

    
    }
}
