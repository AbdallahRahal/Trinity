using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Armor : Equipement 
    {

        readonly Dictionary<string, int> _stats;
        string _type;


        internal Armor(string name, string type, Dictionary<string, int> stats) : base (name)
        {
            _stats = stats;
            _type = type;
        }

    }
}
