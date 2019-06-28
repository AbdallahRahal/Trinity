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

        public Electrocute(Gem _gem) 
        {
            gem = _gem;
        }

        public void action(List<Minion> Fighters ,Minion focus, Minion focusheal) { 
            foreach (Minion min in Fighters)
            {
                if (focus == min)
                {
                    //bubbleFight.Change_type(15, minionPos[minionAction.targetMin]);
                }
                else
                {
                    //bubbleFight.Change_type(8, minionPos[minionAction.targetMin]);
                }
            }
        }
        public string description()
        {
            return " Electrocute tout les ennemies, inflige plus de degats au focus";
        }
        public void update()
        {

        }
    }
}
