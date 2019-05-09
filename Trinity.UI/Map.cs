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
        int mapwidth = 100;
        int mapheight = 100;

        public Map(RenderWindow window,string typemap)
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
                reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "../../../Maps/map_fight_trinity.csv"));
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
                    tiles[x, y].Position = new SFML.System.Vector2f(tilesize*window.Size.X/1700 * x, tilesize * window.Size.Y / 900 * y);
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
                    //x = /1700
                   window.Draw(tiles[x, y]);
                }
            }
        }
    }
}
