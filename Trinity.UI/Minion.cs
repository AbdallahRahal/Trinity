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

    class MinionItem
    {

        Sprite sprite;
        RenderWindow window;
        // MinionDescription minionDescription;
        Dictionary<string, Minion> minion;


        public MinionItem(Dictionary<string, Minion> minionDictionnary, RenderWindow newWindow)
        {
            minion = minionDictionnary;
            window = newWindow;
        }

        public void Draw(Sprite inventorySprite)
        {






        }

    }
}
