using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Trinity.UI
{
    class Map
    {
        Sprite[,] tiles;
        int mapwidth = 54;
        int mapheight = 29;

        public Map(RenderWindow window, string typemap)
        {
            int tilemapwidth = 64;
            int tilemapheight = 32;
            int tilesize = 32;

            Texture texture = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Maps/terrain.png"));

            Sprite[] tilemap = new Sprite[tilemapwidth * tilemapheight];

            for (int y = 0; y < tilemapheight; y++)
            {
                for (int x = 0; x < tilemapwidth; x++)
                {
                    IntRect rect = new IntRect(x * tilesize, y * tilesize, tilesize, tilesize);
                    tilemap[(y * tilemapwidth) + x] = new Sprite(texture, rect);
                }
            }

            tiles = new Sprite[mapwidth, mapheight];
            StreamReader reader;
            if (typemap == "fight")
            {
                if (System.IO.File.Exists(@"C:\Trinity\Trinity.UI\Maps\NewMap.csv") && System.IO.File.Exists(@"C:\Trinity\Trinity.UI\bin\Debug\netcoreapp2.1\NewMap.csv"))
                {
                    System.IO.File.Delete(@"C:\Trinity\Trinity.UI\Maps\NewMap.csv");
                    System.IO.File.Delete(@"C:\Trinity\Trinity.UI\bin\Debug\netcoreapp2.1\NewMap.csv");
                }
                Generate_Csv_Map();
                //A array of Maps
                //string[] maps = { "map_trinity", "hell_tower" };

                reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "../../../Maps/NewMap.csv"));
            }
            else
            {
                reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "../../../Maps/map_trinity.csv"));
            }

            for (int y = 0; y < mapheight; y++)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                for (int x = 0; x < mapwidth; x++)
                {
                    int id = Convert.ToInt32(items[x]);
                    tiles[x, y] = new Sprite(tilemap[id]);
                    tiles[x, y].Position = new SFML.System.Vector2f(tilesize * window.Size.X / 1700 * x, tilesize * window.Size.Y / 900 * y);
                }
            }
            reader.Close();
        }

        public void Draw(RenderWindow window)
        {
            for (int y = 0; y < mapheight; y++)
            {
                for (int x = 0; x < mapwidth; x++)
                {
                    window.Draw(tiles[x, y]);
                }
            }
        }

        static void Generate_Csv_Map()
        {
            int lines = 29;
            int columns = 54;
            int mur = 854;
            int[] gazon = { 968, 970, 974, 834, 957 };

            int[] tuiles = { 930, 935, 817, 927, 928 };

            Random rand = new Random();

            string fileName = @"C:\Trinity\Trinity.UI\Maps\NewMap.csv";

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                for (int i = 0; i < lines; i++)
                {
                    List<string> line = new List<string>();
                    for (int j = 0; j < columns; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            line.Add($"{mur}");
                        }
                        else
                        {
                            int index = rand.Next(tuiles.Length);

                            line.Add($"{tuiles[index]}");
                        }

                    }
                    writer.WriteLine(string.Join(",", line));
                }
            }



        }

    }
}


    }
}