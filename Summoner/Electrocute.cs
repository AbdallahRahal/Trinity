using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinity
{
    class Electrocute
    {
        Gem gem;
        public float lastuse = 0;
        public float cooldown = 15;

        public Electrocute(Gem _gem) 
        {
            gem = _gem;
        }

        public void action(List<Minion> Fighters ,Minion focus, Minion focusheal, float time) {

            if (lastuse + cooldown < time)
            {
                Console.WriteLine("Compétence utilisé ");
                lastuse = time;
                cooldown = 15;
                foreach (Minion min in Fighters)
                {
                    if (focus == min)
                    {
                        min.takeDamage(35);
                    }
                    else if (!min.summMin())
                    {
                        min.takeDamage(18);
                    }
                }
            }
            Console.WriteLine("Prochaine utilisation dans " + (cooldown - (time - lastuse)));

        }
        public string description()
        {
            return " Electrocute tout les \n ennemies, inflige plus \n de degats au focus";
        }
        public void update()
        {

        }
    }
}
