using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using System.IO;

namespace Trinity.UI
{
    public static class DebugUtility
    {
        readonly static string _currentDirectory = Directory.GetCurrentDirectory();
        private static string CONSOLE_FONT_PATH = Path.Combine( _currentDirectory, "fonts/arial.ttf");
        public static Font consoleFont;


        public static void LoadContent ()
        {
            consoleFont = new Font(CONSOLE_FONT_PATH);
        }

        public static void DrawPerformanceData(GameLoop gameLoop, Color fontColor)
        {
            if (consoleFont == null)
                return;

            string totalTimeElapsedStr = gameLoop.GameTime.TotalTimeElapsed.ToString("0.000");
            string deltaTimeStr = gameLoop.GameTime.DeltaTime.ToString("0.00000");
            float fps = 1f / gameLoop.GameTime.DeltaTime;
            string fpsStr = fps.ToString("0.00");

            Text text = new Text(totalTimeElapsedStr, consoleFont, 14);
            text.Position = new Vector2f(4f, 8f);
            text.FillColor = fontColor;

            Text textB = new Text(totalTimeElapsedStr, consoleFont, 14);
            textB.Position = new Vector2f(4f, 28f);
            textB.FillColor = fontColor;

            Text textC = new Text(totalTimeElapsedStr, consoleFont, 14);
            textC.Position = new Vector2f(4f, 48f);
            textC.FillColor = fontColor;

            gameLoop.Window.Draw(text);
            gameLoop.Window.Draw(textB);
            gameLoop.Window.Draw(textC);
        }
    }
}
