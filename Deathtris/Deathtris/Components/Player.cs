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
        Vector2 velocity = new Vector2(0, 0);
        Vector2 acceleration = new Vector2(0, 0);
        Vector2 gravity = new Vector2(0, 9.82f);
        bool hasJumped;


        public Player(float speed, float jumpSpeed)
        {
            this.speed = speed;
            this.jumpSpeed = jumpSpeed;
            hasJumped = true;
        }

        public void Move(Vector2 moveVelocity)
        {
            
            if (moveVelocity != Vector2.Zero)
            {
                moveVelocity.Normalize();
            }
            moveVelocity *= speed;
            this.acceleration = moveVelocity;
            
        }

        public void Jump(Vector2 jumpVelocity)
        {

            if (jumpVelocity != Vector2.Zero)
            {
                jumpVelocity.Normalize();
            }
            jumpVelocity *= jumpSpeed;
            this.acceleration = jumpVelocity;
            
        }

        

        public override void Update(GameTime gameTime)
        {
            InputHandler.Instance.Execute(this);
            this.velocity = new Vector2(this.velocity.X * 0.5f, this.velocity.Y);
            this.velocity += gravity + acceleration;
            gameObject.GetTransform.Translation(this.velocity);
            var i = gameObject.GetTransform.Position.Y;
            i = Math.Min(1080-200, i);
            var newPos = new Vector2(gameObject.GetTransform.Position.X, i);
            gameObject.GetTransform.Position = newPos;

        }
    }
}
