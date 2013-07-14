using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;

namespace RiversideLegends
{
    public static class KeyHandler
    {
        public static void process(TCODKey par1)
        {
            switch (par1.KeyCode)
            {
                case TCODKeyCode.Escape:
                    Game.endGame = true;
                    break;
            }
        }
    }
}
