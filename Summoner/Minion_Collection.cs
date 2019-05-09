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
        Tower _context;

        public Minion_Collection(Tower context)
        {
            _minions = new Dictionary<string, Minion>();
            _context = context;
        }

        /// <summary>
        /// Creates a new minion in this collection.
        /// </summary>
        /// <param name="name">name of the new minion. This name must be unique otherwise an <see cref="ArgumentException"/> is thrown.</param>
        /// <returns>The newly created minion.</returns>
        public Minion Create_Minion(string name, uint power, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy, string path)
        {
            if (_minions.ContainsKey(name)) throw new ArgumentException("A minion with this name already exists.", nameof(name));
            Minion minion = new Minion(name, power, max_life_point, max_mana_point, dodge_rate, accuracy, path, _context);
            _minions.Add(name, minion);
            return minion;
        }

        public Minion Find_By_Name( string name)
        {
            Minion minion;
            _minions.TryGetValue(name, out minion);
            return minion;
        }

        public void Remove_Minion ( Minion minion)
        {
            _minions.Remove(minion.Name);
        }

        public void On_Rename( Minion minion, string newName)
        {
            if (_minions.ContainsKey(newName)) throw new ArgumentException(" A minion with this name already exists.", nameof(newName));
            _minions.Remove(minion.Name);
            _minions.Add(newName, minion);
        }

        public Dictionary<string, Minion> Minion_Dictionnary
        {
            get { return _minions; }
        }

    }
}
