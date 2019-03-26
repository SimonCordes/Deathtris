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
    class SpriteRenderer : Component
    {
        private string spriteName;
        private Texture2D sprite;

        /// <summary>
        /// Constructor for a spriterenderer without any animations.
        /// </summary>
        /// <param name="gameObject"></param>
        /// <param name="spriteName"></param>
        public SpriteRenderer(GameObject gameObject, string spriteName)
        {
            this.spriteName = spriteName;
        }

        /// <summary>
        /// Loads the content for the sprite needed.
        /// </summary>
        /// <param name="content"></param>
        public override void LoadContent(ContentManager content)
        {
            sprite = GameWorld.ContentManager.Load<Texture2D>(spriteName);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, gameObject.GetTransform.Position, Color.White);
        }
    }
}
