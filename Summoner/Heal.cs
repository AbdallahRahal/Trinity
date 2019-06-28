using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    class Heal
    {
        Gem gem;

        public Heal(Gem _gem)
        {
            gem = _gem;
        }

        public void action(List<Minion> Fighters, Minion focus, Minion focusheal)
        {
            if (focusheal != null)
            {
                //soigne de 20 sur focus heal
            }
            else
            {
                Minion minheal;
                int lp = 0;
                foreach (Minion min in Fighters)
                {
                    if (min._summoner == this.gem.wearer._summoner)
                    {
                        if (min.Life_point > lp)
                        {
                            minheal;
                        }

                    }
                }
            }
        }
            public void update()
        {

        }

        public string description()
        {
            return " Soigne le focus allié si il existe, sinon soigne l'allié avec le plus bas taux de point de vie";
        }
    }
}
