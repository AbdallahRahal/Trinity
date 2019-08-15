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
        public float lastuse = 0;
        public float cooldown = 12;

        public Heal(Gem _gem)
        {
            gem = _gem;
        }

        public void action(List<Minion> Fighters, Minion focus, Minion focusheal, float time)
        {
            if (lastuse + cooldown < time)
            {
               
                lastuse = time;
                cooldown = 15;
                if (focusheal != null)
                {
                    focusheal.Life_point += Math.Min(40, focusheal.Max_life_point-focusheal.Life_point);
                    Console.WriteLine("Compétence heal utilisé sur "+ focusheal.Name);
                }
                else
                {
                    Minion minheal = gem.wearer;
                    int lp = 999999;
                    foreach (Minion min in Fighters)
                    {
                        if (gem.wearer._summoner == min._summoner )
                        {
                            if ((int)(min.Life_point/ min.Max_life_point * 100) < lp)
                            {
                                minheal = min;
                                lp = (int)(min.Life_point / min.Max_life_point * 100);
                            }

                        }
                    }
                    
                    minheal.Life_point += Math.Min(40, minheal.Max_life_point - minheal.Life_point);

                    Console.WriteLine("Compétence heal utilisé sur " + minheal.Name);
                }
            }
            Console.WriteLine("Prochaine utilisation dans " + (cooldown - (time - lastuse)));

        }
        public void update()
        {

        }

        public string description()
        {
            return " Soigne le focus allié \n si il existe, sinon soigne \n l'allié avec le plus bas \n taux de point de vie";
        }
    }
}
