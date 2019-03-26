using Deathtris.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris
{
    public class GameObject
    {
        private List<Component> components = new List<Component>();
        private readonly Transform transform;
        public Transform GetTransform { get { return transform; } }

        public GameObject(Vector2 position)
        {
            transform = new Transform(this, position);
        }


        public Component GetComponent(string componentName)
        {
            foreach (Component component in components)
            {
                if (component.GetType().Name == componentName)
                {
                    return component;
                }

            }

            return null;

        }

        /// <summary>
        /// Calls LoadConent on all components on the GameObject.
        /// </summary>
        /// <param name="content">Content Manager of the game</param>
        public virtual void LoadContent(ContentManager content)
        {
            foreach (Component component in components)
            {
                component.LoadContent(content);
            }
        }

        /// <summary>
        /// Calls update on all attached components
        /// </summary>
        /// <param name="gameTime">Time since last update</param>
        public virtual void Update(GameTime gameTime)
        {
            foreach (Component component in components)
            {
                component.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components)
            {
                component.Draw(spriteBatch);
            }
        }
        
        /// <summary>
        /// Removes the GameObject from the world.
        /// </summary>
        public virtual void Destroy()
        {
            GameWorld.RemoveGameObject(this);
        }

    }
}
