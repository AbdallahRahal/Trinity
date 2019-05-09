using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Breastplate : Equipement_Nospell
        {
            public Breastplate(string name, uint price, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy,string path) : base(name, price, max_life_point, max_mana_point, dodge_rate, accuracy,path)
            {
            }
        }
    
}