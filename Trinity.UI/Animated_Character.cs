using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using SFML.Audio;

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
        public float Xpos = 818;
        public float Ypos = 770;

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

        public Animated_Character(string filename, int frameSize)
        {
            this.frameSize = frameSize;
            Texture texture = new Texture(filename);

            spriteRect = new IntRect(0, 0, frameSize, frameSize);
            sprite = new Sprite(texture, spriteRect);


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

            if(animationClock.ElapsedTime.AsSeconds() > animationSpeed)
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
        public void Draw(RenderWindow window)
        {
            window.Draw(sprite);
        }

    }
}
