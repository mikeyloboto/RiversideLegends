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
                case TCODKeyCode.F12:
                    Game.endGame = true;
                    
                    break;
                case TCODKeyCode.F2:
                    Game.addMsg("Please, do not press this button again!", TCODColor.red);
                    break;
                case TCODKeyCode.F1:
                    if (Game.showHelp == false)
                    {
                        Game.showHelp = true;
                    }
                    else
                    {
                        Game.showHelp = false;
                    }
                    break;
                case TCODKeyCode.F3:
                    if (Game.isPaused)
                    {
                        Game.unpause();
                    }
                    else
                    {
                        Game.pause();
                    }
                    break;
                case TCODKeyCode.F11:
                    //Game.toggleFullscreen();
                    break;

                case TCODKeyCode.Up:
                    Game.move(0);
                    break;
                case TCODKeyCode.Right:
                    Game.move(1);
                    break;
                case TCODKeyCode.Down:
                    Game.move(2);
                    break;
                case TCODKeyCode.Left:
                    Game.move(3);
                    break;

                    //
                    // Temp for testing purposes
                    //

                case TCODKeyCode.KeypadFive:
                    Game.player.addExp(15);
                    break;
                case TCODKeyCode.KeypadEight:
                    Game.player.damage(2);
                    break;
                case TCODKeyCode.KeypadTwo:
                    Game.player.heal(2);
                    break;

            }
        }
    }
}
