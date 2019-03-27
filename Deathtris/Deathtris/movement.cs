using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Deathtris.Components;

namespace Deathtris
{
    class movement: ICommand
    {
        private Vector2 velocity;

        public movement(Vector2 velocity)
        {
            this.velocity = velocity;
        }
        public void Execute(Player player)
        {
            player.Move(velocity);
        }
    }
}
