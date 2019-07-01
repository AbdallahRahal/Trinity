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
        string _type;

        public Gem(string name,string type, uint price,string path) : base(name, price, path)
        {
           
            _type = type;
            switch (_type)
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
        public float cooldown(float time)
        {
            switch (_type)
            {
                case "electrocute":
                    return spellEle.cooldown - (time - spellEle.lastuse);
                   
                    break;
                case "heal":
                    return spellHeal.cooldown - (time - spellHeal.lastuse);
                    break;
                default:
                    return 0f;
                    break;
            }

        }
        public void action(List<Minion> Fighters, Minion focus, Minion focusheal, float time)
        {
            List<Minion> _Fighters = new List<Minion>();
            foreach (Minion min in Fighters)
            {
                if (min.is_alive())
                {
                    _Fighters.Add(min);
                }
            }


            switch (_type)
            {
                case "electrocute":
                    spellEle.action(Fighters,focus,focusheal, time);
                    break;
                case "heal":
                    spellHeal.action(Fighters, focus, focusheal, time);
                    break;
                default:
                    break;
            }
        }

    }
}
