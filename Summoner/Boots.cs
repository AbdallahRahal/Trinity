﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Boots : Equipement_Nospell
    {
        public Boots(string name, uint max_life_point, uint max_mana_point, uint dodge_rate, uint accuracy) : base(name, max_life_point, max_mana_point, dodge_rate, accuracy)
        {
        }
    }
}