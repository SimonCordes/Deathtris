using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deathtris.Components;
using Microsoft.Xna.Framework;

namespace Deathtris
{
    class InputHandler
    {
        static InputHandler instance;
        private Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();
        public PlayerDirection playerDirection = PlayerDirection.Idle;
        public InputHandler()
        {
            keybinds.Add(Keys.A, new movement(new Vector2(-1, 0), PlayerDirection.Left));
            keybinds.Add(Keys.D, new movement(new Vector2(1, 0), PlayerDirection.Right));
            keybinds.Add(Keys.W, new movement(new Vector2(0, 1), PlayerDirection.Jumping));
        }
        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }

        public void Execute(Player player)
        {
            KeyboardState keystate = Keyboard.GetState();

            foreach (Keys key in keybinds.Keys)
            {
                if (keystate.IsKeyDown(key))
                {
                    keybinds[key].Execute(player);
                }
            }
        }
    }
}
