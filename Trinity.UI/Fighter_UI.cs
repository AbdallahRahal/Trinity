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
    class Fighter_UI
    {

        List<Minion> Fighters;
        static Sprite sprite;
        static Texture texture;
        Sprite spellSprite;
        Tower _context;
        Sprite borderspell = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/borderspell.png")));
        static Texture textureLifeBarEmpty;

        static Sprite spriteLifeBar;
        static Texture textureLifeBar = new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Lifebar.png"));

        static Sprite spriteRound;
        static Texture textureRound;
        static Font font = new Font(Path.Combine(Directory.GetCurrentDirectory(), "../../../Fonts/Arial.ttf"));
        static Text text = new Text("Test description objet", font, 16);
        static Text textcd = new Text("CD gem", font, 25);
        RenderWindow _window;
        static Sprite spriteLifeBarEmpty = new Sprite(new Texture(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/EmptyLifeBar.png")));
        double percentLife;
        int y ;
        ItemDescription description;
        int x ;

        public Fighter_UI(RenderWindow window, Tower tower, List<Minion> _Fighters)
        {
            _context = tower;
            Fighters = _Fighters;
            _window = window;
            textureRound = new Texture((Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/TargetRound.png")));
            spriteRound = new Sprite(textureRound);
        }



        public void Draw(List<Minion> _Fighters, float time)
        {
            Fighters = _Fighters;
            y = 0;
            x = 0;
            foreach(Minion fighter in _Fighters)
            {
                texture = new Texture(fighter.Path);
                sprite = new Sprite(texture);
                sprite.Scale = new Vector2f(_window.Size.X / 1700f, _window.Size.Y / 900f);

                if (fighter.summMin())
                {
                    sprite.Position = new Vector2f(78f  * _window.Size.X / 1700f, (635f + y * 70f) * _window.Size.Y / 900f);
                }
                else
                {
                    sprite.Position = new Vector2f((78f + 1000 ) * _window.Size.X / 1700f, (635f + y * 70f) * _window.Size.Y / 900f);

                }
                
                spriteLifeBarEmpty.Position = new Vector2f(sprite.Position.X + 60f, sprite.Position.Y + 15f);

                percentLife = ((double)fighter.Life_point / (double)fighter.Max_life_point) * 100 ;

                for (int barNmb = 0; barNmb < percentLife; barNmb++)
                {

                    spriteLifeBar = new Sprite(textureLifeBar);
                    spriteLifeBar.Position = new Vector2f(sprite.Position.X + 62f + 4f * (float)barNmb, sprite.Position.Y + 17f);

                    _window.Draw(spriteLifeBar);
                }
                
                text.DisplayedString = fighter.Name+"  Vie : " + fighter.Life_point+"/"+fighter.Max_life_point;
                text.Position = new Vector2f(sprite.Position.X + 60f, sprite.Position.Y+50f);
                text.FillColor = new Color(0, 0, 0);

                if (_context.Summoner.Inventory.ContainMinion(fighter) && fighter.Armories.Gem != null) {
                    spellSprite = new Sprite(new Texture(fighter.Armories.Gem.Path));
                    spellSprite.Position = new Vector2f(555f * _window.Size.X / 1700f, (640 + y * 70f) * _window.Size.Y / 900f);
                    borderspell.Position = spellSprite.Position;
                    if (fighter.Armories.Gem.cooldown(time) > 0)
                    {
                        textcd.DisplayedString = fighter.Armories.Gem.cooldown(time).ToString("#");
                    }
                    else
                    {
                        textcd.DisplayedString = "0";
                    }
                    textcd.Position = new Vector2f(spellSprite.Position.X + 60, spellSprite.Position.Y +15);
                    textcd.FillColor = new Color(0, 0, 0);

                    _window.Draw(borderspell);
                    _window.Draw(spellSprite);
                    _window.Draw(textcd);

                    if (spellSprite.Position.X < Mouse.GetPosition(_window).X && Mouse.GetPosition(_window).X < spellSprite.Position.X + 54f
                     && spellSprite.Position.Y < Mouse.GetPosition(_window).Y && Mouse.GetPosition(_window).Y < spellSprite.Position.Y + 54f)
                    {
                        description = new ItemDescription(fighter.Armories.Gem, _window);
                        description.Draw(_window);
                    }
                }

                y++;
                if (y == 3) y = 0;
                _window.Draw(spriteLifeBarEmpty);
                _window.Draw(sprite);
                _window.Draw(text);
            }





        }
    }
}
