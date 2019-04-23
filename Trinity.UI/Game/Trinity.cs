using System;
using System.Collections.Generic;
using System.Text;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Trinity.UI
{
    public class Trinity : GameLoop
    {
        public const uint DEFAULT_WINDOW_WIDTH = 640;
        public const uint DEFAULT_WINDOW_HEIGHT = 480;

        public const string WINDOW_TITLE = "Trinity";

        public Trinity() : base (DEFAULT_WINDOW_WIDTH, DEFAULT_WINDOW_HEIGHT, WINDOW_TITLE, Color.Blue)
        {
           
        }

        public override void Draw(GameTime gameTime)
        {
            DebugUtility.DrawPerformanceData(this, Color.White);
        }

        public override void Initialize()
        {
            WindowClearColor = Color.Blue;
        }

        public override void LoadContent()
        {
            DebugUtility.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
