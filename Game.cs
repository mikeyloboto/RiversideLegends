using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using libtcod;

namespace RiversideLegends
{
    public static class Game
    {
        public static bool endGame;
        private static void Main()
        {
            TCODConsole.initRoot(170, 100, Enum.CurrentName + " " + Enum.Version, false, TCODRendererType.OpenGL);
            //TCODConsole.mapAsciiCodesToFont(0, 255, 0, 0);
            //TCODConsole.setCustomFont("terminal2.png", (int)libtcod.TCODFontFlags.LayoutAsciiInRow);
            
            TCODSystem.setFps(25);
            endGame = false;
            while (!endGame && !TCODConsole.isWindowClosed())
            {
                TCODConsole.root.print(0, 0, "TEST");
                TCODConsole.root.print(15, 15, "Test 2");
                TCODConsole.flush();
                var key = TCODConsole.checkForKeypress();
                KeyHandler.process(key);
            }
        }
            
    }
}
