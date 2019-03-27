using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    public enum PlayerDirection
    {
        Idle,
        Left,
        Right,
        Jumping,
        //JumpingLeft,
        //JumpingRight
    }

    class AnimatedSpriteRenderer : Component
    {
        private string spriteName;
        private Texture2D sprite;
        private Rectangle[,] animationRectangleSheet;
        protected double timeElapsed = 0;
        protected int currentAnimationIndex = 0;
        private float animationFPS;
        private int frameCountHeight;
        private int frameCountWidth;
        private PlayerDirection playerDirection = PlayerDirection.Idle;


        /// <summary>
        /// AnimationRectangle used to draw the player with the SpriteSheet, depending on which direction he is turning / jumping.
        /// </summary>
        public Rectangle CurrentAnimationRectangle { get => animationRectangleSheet[(int)PlayerDirection, currentAnimationIndex]; }
        /// <summary>
        /// Used to get and set the direction the player is moving in.
        /// </summary>
        public PlayerDirection PlayerDirection { get => playerDirection; set => playerDirection = value; }

        /// <summary>
        /// Constructor for a sprite with animation.
        /// </summary>
        /// <param name="gameObject">A reference to the gameobject.</param>
        /// <param name="spriteName">The name of the sprite</param>
        /// <param name="animationFPS">How many times the sprite should be rendered</param>
        /// <param name="frameCountHeight">How high the spritesheet is</param>
        /// <param name="frameCountWidth">How wide the spritesheet is</param>
        public AnimatedSpriteRenderer(GameObject gameObject, string spriteName, int animationFPS, int frameCountHeight, int frameCountWidth)
        {
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
            this.frameCountHeight = frameCountHeight;
            this.frameCountWidth = frameCountWidth;
            this.spriteName = spriteName;
            this.animationFPS = animationFPS;
            animationRectangleSheet = new Rectangle[frameCountHeight, frameCountWidth];
            int height = sprite.Height / frameCountHeight;
            int width = sprite.Width / frameCountWidth;

            for (int x = 0; x < frameCountWidth; x++)
            {
                for (int y = 0; y < frameCountHeight; y++)
                {
                    animationRectangleSheet[y,x] = new Rectangle(x * width, y * height, width, height);
                }
            }

        }
        /// <summary>
        /// Loads the content for the sprite needed.
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {

        }

        private void ChangeDirection()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Keys.A))
            {
                PlayerDirection = PlayerDirection.Left;
               
            }
            else if (keyState.IsKeyDown(Keys.D))
            {
                PlayerDirection = PlayerDirection.Right;
            }
            else { PlayerDirection = PlayerDirection.Idle; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, gameObject.GetTransform.Position, CurrentAnimationRectangle, Color.White);

        }

        public override void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);
            if (currentAnimationIndex >= frameCountWidth)
            {
                timeElapsed = 0;
                currentAnimationIndex = 0;
            }
            ChangeDirection();

        }

    }
}
