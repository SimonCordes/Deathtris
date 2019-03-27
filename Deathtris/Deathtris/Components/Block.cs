using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deathtris.Components
{
    public enum BlockType
    {
        Square,
        Line
    }

    class Block : Component
    {

        bool isMoving;
        Vector2 position;

        public Vector2 Position { get => position; set => position = value; }


        public Block(BlockType blockType)
        {
            
        }

        public void MoveBlock(Vector2 velocity)
        {
            position = gameObject.GetTransform.Position;

            while (isMoving)
            {
                position -= velocity;
            }
            
        }

        public void StopBlock()
        {
            if (true)
            {

            }
        }




    }
}
