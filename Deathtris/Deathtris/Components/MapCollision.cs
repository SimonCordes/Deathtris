using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    public class MapCollision : Component
    {
        private Vector2 position;
        private Texture2D sprite;
        public MapCollision(GameObject gameObject)
        {
            gameObject.AddComponent(this);
        }
        
            public override void CollisionSetup()
        {
            base.CollisionSetup();
        }

        public Rectangle CollisionBox
        {
            get
            {
                position = gameObject.GetTransform.Position;
                sprite = gameObject.GetSpriteRender.Sprite;

                return new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            }
        }
        public bool IsColliding(MapCollision collision)
        {
            return CollisionBox.Intersects(collision.CollisionBox);
        }
    }
}
