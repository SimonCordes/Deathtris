using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
        private PlayerDirection playerDirection = PlayerDirection.Idle;


        /// <summary>
        /// AnimationRectangle used to draw the player with the SpriteSheet, depending on which direction he is turning / jumping.
        /// </summary>
        public Rectangle CurrentAnimationRectangle { get => animationRectangleSheet[(int)PlayerDirection, currentAnimationIndex]; }
        /// <summary>
        /// Used to get and set the direction the player is moving in.
        /// </summary>
        protected PlayerDirection PlayerDirection { get => playerDirection; set => playerDirection = value; }

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
            
            this.spriteName = spriteName;
            this.animationFPS = animationFPS;
            animationRectangleSheet = new Rectangle[frameCountHeight, frameCountWidth];
            int height = sprite.Height / frameCountHeight;
            int width = sprite.Width / frameCountWidth;

            for (int x = 0; x < frameCountHeight; x++)
            {
                for (int y = 0; y < frameCountWidth; y++)
                {
                    animationRectangleSheet[x, y] = new Rectangle(x * width, y * height, width, height);
                }
            }

        }
        /// <summary>
        /// Loads the content for the sprite needed.
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {


        }

        public override void Update(GameTime gameTime)
        {
            timeElapsed += gameTime.ElapsedGameTime.TotalSeconds;
            currentAnimationIndex = (int)(timeElapsed * animationFPS);
            if (currentAnimationIndex > animationRectangleSheet.GetLength(0) - 1)
            {
                timeElapsed = 0;
                currentAnimationIndex = 0;
            }

        }

    }
}
