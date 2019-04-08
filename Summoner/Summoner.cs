using System;
using System.Collections.Generic;
using System.Text;

namespace Trinity
{
    public class Summoner
    {
        readonly string name;
        readonly Dictionary<string, Inventory> _inventories;
        uint floor_level;
    }
}
