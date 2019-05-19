﻿using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;
using System.IO;

namespace Trinity.UI
{
    public enum CharacterState
    {
        None,
        MovingUp,
        MovingLeft,
        MovingDown,
        MovingRight
    }
    abstract class Animated_Character
    {
        public float Xpos;
        public float Ypos;
        public bool _Open_Shop = false;
        public Vector2f OldPlace;
        float xscale;
        float yscale;

        private Sprite sprite;
        private IntRect spriteRect;
        private int frameSize;

        public CharacterState CurrentState { get; set; }

        protected Animation Anim_Up;
        protected Animation Anim_Left;
        protected Animation Anim_Down;
        protected Animation Anim_Right;
        

        private Clock animationClock;
        protected float moveSpeed = 50  ;
        protected float animationSpeed = 0.1f;

        public Animated_Character(string filename, int frameSize, RenderWindow window)
        {

            Xpos = 1400 * window.Size.X / 1700; //818
            Ypos = 250 * window.Size.Y / 900; //770
            xscale = window.Size.X / 1700;
            yscale = window.Size.Y / 900;
            this.frameSize = frameSize;
            Texture texture = new Texture(filename);

            spriteRect = new IntRect(0, 0, frameSize, frameSize);
            sprite = new Sprite(texture, spriteRect);
            sprite.Scale = new Vector2f((float)window.Size.X / 1700f, (float)window.Size.Y / 900f);

            animationClock = new Clock();

        }

        public virtual void Update(float deltaTime)
        {
            Animation currentAnimation = null;


            switch(CurrentState)
            {
                case CharacterState.MovingUp:
                    currentAnimation = Anim_Up;
                    Ypos -= moveSpeed * deltaTime;
                    break;
                case CharacterState.MovingLeft:
                    currentAnimation = Anim_Left;
                    Xpos -= moveSpeed * deltaTime;
                    break;
                case CharacterState.MovingDown:
                    currentAnimation = Anim_Down;
                    Ypos += moveSpeed * deltaTime;
                    break;
                case CharacterState.MovingRight:
                    currentAnimation = Anim_Right;
                    Xpos += moveSpeed * deltaTime;
                    break;
            }

            sprite.Position = new Vector2f(Xpos, Ypos);
            //previousX = sprite.Position.X;
            //previousY = sprite.Position.Y;

            if (animationClock.ElapsedTime.AsSeconds() > animationSpeed)
            {
                if(currentAnimation != null)
                {
                    //spriteRect.Top = currentAnimation.offsetTop;
                    spriteRect = new IntRect(spriteRect.Left, currentAnimation.offsetTop, frameSize, frameSize);

                    if (spriteRect.Left == (currentAnimation.numFrames - 1) * frameSize)
                        //spriteRect.Left = 0;
                    spriteRect = new IntRect(0, spriteRect.Top, frameSize, frameSize);
                    else
                        //spriteRect.Left += frameSize;
                    spriteRect = new IntRect(spriteRect.Left + frameSize, spriteRect.Top, frameSize, frameSize);
                }
                animationClock.Restart();
            }
            moveSpeed = 150;
            sprite.TextureRect = spriteRect;
        }

        /// <summary>
        /// initialize tiles table map and detecte collision
        /// </summary> 
        public void collide()
        { 
            StreamReader reader = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "../../../Maps/map_trinity.csv"));
            int[,] tabmap = new int[100,100];
            for (int y = 0; y < 100; y++)
            {
                string line = reader.ReadLine();
                string[] items = line.Split(',');

                for (int x = 0; x < 100; x++)
                {
                    int id = Convert.ToInt32(items[x]);
                    tabmap[x,y] = id;
                }
            }
            reader.Close();

            //for (int y = 0; y < 100; y++)
            //{
            //    for (int x = 0; x < 100; x++)
            //    {
            //        int top = y * 32;
            //        int bottom = y * 32 + 32;
            //        int left = x * 32;
            //        int right = x * 32 + 32;
                   
                    
            //    }
            //}

            /*if (((Xpos < 0 && (0 < Ypos && Ypos < 800)) || (Xpos > 1615 && (0 < Ypos && Ypos < 800) || 
                (Ypos < 0 && (0 < Xpos && Xpos < 1615)) || (Ypos > 800 && (0 < Xpos && Xpos < 1615)))))*/
            if (Xpos < 20 || Xpos > 1615 || Ypos < 5 || Ypos > 795)
            {
                this.sprite.Position = new Vector2f(Xpos, Ypos);
                OldPlace = new Vector2f(Xpos, Ypos);
                Console.WriteLine("collision mur " + OldPlace);

                if(Keyboard.IsKeyPressed(Keyboard.Key.Left) && Xpos < 20)
                {
                    Console.WriteLine("collision gauche");
                    moveSpeed = 0;
                } else

                    if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && Xpos > 1615)
                {
                    Console.WriteLine("collision droite");
                    moveSpeed = 0;
                } else

                    if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && Ypos < 5)
                {
                    Console.WriteLine("collision haut");
                    moveSpeed = 0;
                } else

                    if(Keyboard.IsKeyPressed(Keyboard.Key.Down) && Ypos > 795)
                {
                    Console.WriteLine("collision bas");
                    moveSpeed = 0;
                }

            }
            if (1280 < Xpos && Xpos < 1629 && 63  < Ypos && Ypos < 223)
            {
                _Open_Shop = true;
                //Console.WriteLine("collision shop ");

            }
            else
            {
                _Open_Shop = false;
                
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

    }
}
