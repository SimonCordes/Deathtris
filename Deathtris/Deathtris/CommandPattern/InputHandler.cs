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
        public InputHandler()
        {
            keybinds.Add(Keys.A, new MoveCommand(new Vector2(-10, 0)));
            keybinds.Add(Keys.D, new MoveCommand(new Vector2(10, 0)));
            keybinds.Add(Keys.W, new JumpCommand(new Vector2(0, -10)));
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
