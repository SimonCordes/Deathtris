using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    public class BlockCollider : Component
    {
        private Rectangle collisionBox;
        

        public virtual Rectangle CollisionBox
        {
            
            get
            {
                return new Rectangle((int)gameObject.GetTransform.Position.X, (int)gameObject.GetTransform.Position.Y,  )
            }
        }

    }
}
