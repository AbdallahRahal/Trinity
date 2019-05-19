using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;



namespace Trinity.UI
{
    class BubbleFight
    {
        RenderWindow _window;
        Tower _context;

        public BubbleFight(RenderWindow window, Tower tower)
        {
            _context = tower;
            _window = window;








        }

        public void Change_type(int x, FightUI fightUI)
        {
            if(x == -1) // l'attaque a raté
            {
                
            }else if (x >= 0) // l'attaque a réussi
            {
                
            }
        }



        public void Draw()
        {








        }

    }

}
