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
    public class Component
    {

        protected GameObject gameObject;
        public GameObject GetGameObject
        {
            get { return gameObject; }
        }

        public void Attach(GameObject gameObject)
        {
            this.gameObject = gameObject;
        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

       
    }
}
