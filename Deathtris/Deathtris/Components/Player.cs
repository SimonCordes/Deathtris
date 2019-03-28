using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    public class Player : Component
    {
        
        float speed;
        float jumpSpeed;
        float fallSpeed = 0.15f;
        bool hasJumped;


        public Player(float speed, float jumpSpeed)
        {
            this.speed = speed;
            this.jumpSpeed = jumpSpeed;
            hasJumped = true;
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

        public void Jump(Vector2 velocity)
        {

            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }
            velocity *= jumpSpeed;
            gameObject.GetTransform.Translation(velocity * GameWorld.deltaTime);

        }

        

        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);
            
        }
    }
}
