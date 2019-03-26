using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    public class Transform : Component
    {
        private Vector2 position;
        /// <summary>
        /// Gets and returns the position of the gameobject.
        /// </summary>
        public Vector2 Position { get => position; set => position = value; }

        /// <summary>
        /// Constructor for the Transform Component.
        /// </summary>
        /// <param name="movePos"></param>
        public Transform(GameObject gameObject, Vector2 movePos)
        {
            position = movePos;
            this.gameObject = gameObject;
        }
        /// <summary>
        /// The method that handles the movement. 
        /// </summary>
        /// <param name="translation">Determines where the object should be moved to.</param>
        public void Translation(Vector2 translation)
        {
            Position += translation;
        }
    }
}
