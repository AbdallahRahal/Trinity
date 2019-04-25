using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

namespace Trinity.UI
{
    class Player : Animated_Character
    {
        public Player() : base("C:/S3/Trinity/Trinity.UI/Sprites/Sprite_Character.png", 64)
        {
            Anim_Up = new Animation(192, 0, 4);
            Anim_Left = new Animation(64, 0, 4);
            Anim_Down = new Animation(0, 0, 4);
            Anim_Right = new Animation(128, 0, 4);

            moveSpeed = 150;
            animationSpeed = 0.05f;
        }

        public override void Update(float deltaTime)
        {
            this.CurrentState = CharacterState.None;

            if(Keyboard.IsKeyPressed(Keyboard.Key.Z) || Keyboard.IsKeyPressed(Keyboard.Key.Up))
            {
                this.CurrentState = CharacterState.MovingUp;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.Q) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
            {
                this.CurrentState = CharacterState.MovingLeft;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.Down))
            {
                this.CurrentState = CharacterState.MovingDown;
            }
            else if(Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
            {
                this.CurrentState = CharacterState.MovingRight;
            }

            base.Update(deltaTime);
        }
    }
}
