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
    class Player : Animated_Character
    {
        RenderWindow window;
        public Player(RenderWindow _window) : base(Path.Combine(Directory.GetCurrentDirectory(), "../../../Sprites/Sprite_Character.png"), 64,  _window)
        {
            window = _window;
            Anim_Up = new Animation(192, 0, 4);
            Anim_Left = new Animation(64, 0, 4);
            Anim_Down = new Animation(0, 0, 4);
            Anim_Right = new Animation(128, 0, 4);
            
            animationSpeed = 0.05f;
        }

        public override void Update(float deltaTime)
        {
            this.CurrentState = CharacterState.None;

            if(Keyboard.IsKeyPressed(Keyboard.Key.Up) )
            {
                this.CurrentState = CharacterState.MovingUp;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                this.CurrentState = CharacterState.MovingLeft;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                this.CurrentState = CharacterState.MovingDown;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                this.CurrentState = CharacterState.MovingRight;
            }

            if(Keyboard.IsKeyPressed(Keyboard.Key.LShift))
            {
                moveSpeed = 1000;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.O))
            {
                Xpos = 818 * window.Size.X / 1700;
                Ypos = 770 * window.Size.Y / 900;
            }
            base.Update(deltaTime);
        }
    }
}
