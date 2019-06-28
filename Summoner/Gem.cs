using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    public class Gem : Equipement
    {
        Heal spellHeal;
        Electrocute spellEle;
        public Minion wearer;
        public string description;

        public Gem(string name, uint price,string path) : base(name, price, path)
        {
            switch (name)
            {
                case "electrocute" :
                    spellEle = new Electrocute(this);
                    description = spellEle.description();
                    break;
                case "heal" :
                    spellHeal = new Heal(this);
                    description = spellHeal.description();
                    break;
                default:
                    break;
            }

        }
        public string desc()
        {
            return description;
        }
        public void new_Wearer(Minion minion)
        {
            wearer = minion;
        }

    }
}
