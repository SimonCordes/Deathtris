using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deathtris.Components;

namespace Deathtris
{
    interface ICommand
    {
        void Execute(Player player);
    }
}
