using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    class Player : Component
    {
        string test;
        
        float speed;
        Vector2 position = new Vector2(400, 200);

        public Player(float speed)
        { 
            this.speed = speed;
        }

        public void Move(Vector2 velocity)
        {

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            velocity *= speed;
            gameObject.GetTransform.Translation(velocity * GameWorld.deltaTime);
        }
        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);

        }

    }
}
