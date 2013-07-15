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
        public static bool showHelp;
        public static bool isPaused;
        public static Timer actionTimer = new Timer();
        public static TCODMap Map;
        public static Player player;
        public static Dungeon level;
        static int timerCounter;
        static int conWid;
        static int conHei;
        public static int fieldWid;
        public static int fieldHei;
        static List<Message> messages = new List<Message>();
        private static void Main()
        {
            initAll();
            initMap();
            TCODConsole.initRoot(conWid, conHei, Enum.CurrentName + " " + Enum.Version, false, TCODRendererType.OpenGL);
            TCODSystem.setFps(25);
            actionTimer.Start();
            
            //addMsg("Test", TCODColor.purple);
            //addMsg("Abyssal Penguin", TCODColor.green);

            while (!endGame && !TCODConsole.isWindowClosed())
            {
                TCODConsole.root.clear();
                drawBackground();
                drawMsg();
                drawGui();
                drawMap();
                drawMapFeatures();
                //TCODConsole.root.print(1, 12, "@");
                //TCODConsole.root.print(fieldWid + 0, fieldHei + 11, "@");
                //TCODConsole.root.print(30, 30, timerCounter.ToString());
                if (showHelp == true)
                {
                    drawHelp();
                }
                if (isPaused == true)
                {
                    drawPause();
                }
                TCODConsole.flush();
                var key = TCODConsole.checkForKeypress();
                KeyHandler.process(key);
            }
        }

        static void initAll()
        {
            Utils.initUtil();
            resizeAll();
            endGame = false;
            showHelp = false;
            player = new Player();
            timerCounter = 0;
            actionTimer.Interval = 100;
            actionTimer.Tick += actionTimer_Tick;
            messages.Capacity = 8;
            level = new Dungeon(fieldWid, fieldHei);
            for (int i = 0; i < 8; i++)
            {
                messages.Add(new Message(""));
            }
            level.generate();
            player.locX = 50;
            player.locY = 50;
        }

        static void resizeAll()
        {
            conWid = 170;
            conHei = 100;
            fieldWid = conWid - 31;
            fieldHei = conHei - 13;
        }
        public static void pause()
        {
            isPaused = true;
            actionTimer.Stop();
        }
        public static void unpause()
        {
            isPaused = false;
            actionTimer.Start();
        }
        static void drawMapFeatures()
        {
            // Player
            {
                TCODConsole.root.setForegroundColor(player.color);
                TCODConsole.root.print(Utils.WMapToDraw(player.locX), Utils.HMapToDraw(player.locY), player.sym.ToString());
                TCODConsole.root.setForegroundColor(TCODColor.white);

            }
        }
        public static void toggleFullscreen()
        {
            if (TCODConsole.isFullscreen())
            {
                TCODConsole.setFullscreen(false);
            }
            else
            {
                TCODConsole.setFullscreen(true);
            }
        }
        static void drawGui()
        {
            TCODConsole.root.print(conWid - 25, 14, "Health:  " + player.getHpStr());
            TCODConsole.root.printFrame(conWid - 27, 16, 22, 3);
            {
                List<bool> temp = player.getGuiHP();
                for (int i = 1; i < 21; i++)
                {
                    if (temp[i])
                    {
                        TCODConsole.root.setForegroundColor(TCODColor.red);
                        TCODConsole.root.print(conWid - 27 + i, 17, "#");
                        TCODConsole.root.setForegroundColor(TCODColor.white);
                    }
                    else
                    {
                        TCODConsole.root.print(conWid - 27 + i, 17, " ");
                    }
                }
                
            }
            TCODConsole.root.print(conWid - 25, 20, "EXP:  " + player.getExpStr());
            TCODConsole.root.printFrame(conWid - 27, 22, 22, 3);
            {
                List<bool> temp = player.getGuiEXP();
                for (int i = 1; i < 21; i++)
                {
                    if (temp[i])
                    {
                        TCODConsole.root.setForegroundColor(TCODColor.purple);
                        TCODConsole.root.print(conWid - 27 + i, 23, "#");
                        TCODConsole.root.setForegroundColor(TCODColor.white);
                    }
                    else
                    {
                        TCODConsole.root.print(conWid - 27 + i, 23, " ");
                    }
                }

            }

            TCODConsole.root.print(conWid - 25, 26, "Level: " + player.getLevel());
        }
        public static void move(int par1)
        {
            switch (par1)
            {
                case 0:
                    if (level.isWalkable(player.locX, player.locY - 1))
                    {
                        player.locY -= 1;
                    }
                    break;
                case 1:
                    if (level.isWalkable(player.locX + 1, player.locY))
                    {
                        player.locX += 1;
                    }
                    break;
                case 2:
                    if (level.isWalkable(player.locX, player.locY + 1))
                    {
                        player.locY += 1;
                    }
                    break;
                case 3:
                    if (level.isWalkable(player.locX - 1, player.locY))
                    {
                        player.locX -= 1;
                    }
                    break;
            }
        }
        static void drawPause()
        {
            TCODConsole.root.printFrame(3, 3, 11, 5);
            TCODConsole.root.print(5, 5, "Paused.");
        }
        static void initMap()
        {
            Map = new TCODMap(fieldWid, fieldHei);
        }
        static void drawHelp()
        {
            TCODConsole.root.printFrame(20, 20, 90, 70);
            TCODConsole.root.print(22, 22, "Riverside Legends " + Enum.Version + " by Mikey_Loboto, Narrod, Gizr_Padukovich");
            TCODConsole.root.print(22, 24, "Use arrow keys to move.");
            TCODConsole.root.print(22, 85, "Do not press F2!");
            TCODConsole.root.print(22, 26, "Press F3 to pause the game.");
            TCODConsole.root.print(22, 25, "");
            TCODConsole.root.print(22, 26, "");
            TCODConsole.root.print(22, 27, "");
            TCODConsole.root.print(22, 28, "");
            TCODConsole.root.print(22, 29, "");
            TCODConsole.root.print(22, 87, "Use F12 to quit.");


        }
        static void actionTimer_Tick(object sender, EventArgs e)
        {
            if (timerCounter == 10)
            {
                timerCounter = 0;
            }
            else
            {
                timerCounter += 1;
            }
        }
        static void drawBackground()
        {
            TCODConsole.root.setForegroundColor(TCODColor.white);
            //TCODConsole.root.print(1, 1, " Test");
            for (int i = 0; i < conWid; i++)
            {
                TCODConsole.root.print(i, 0, "#");
                TCODConsole.root.print(i, 11, "#");
                TCODConsole.root.print(i, conHei - 1, "#");
            }
            for (int i = 0; i < conHei; i++)
            {
                TCODConsole.root.print(0, i, "#");
                TCODConsole.root.print(conWid - 1, i, "#");
            }
            for (int i = 11; i < conHei; i++)
            {
                TCODConsole.root.print(conWid - 30, i, "#");
            }

        }
        public static void addMsg(String par1, TCODColor par2)
        {
            Message temp = new Message(par1, par2);
            for (int i = 0; i < 7; i++)
            {
                messages[7 - i] = messages[6 - i];
            }
            messages[0] = temp;
        }
        static void drawMsg()
        {
            for (int i = 0; i < 8; i++)
            {
                TCODConsole.root.setForegroundColor(messages[i].Color);
                TCODConsole.root.print(2, 9-i, messages[i].Text);
                TCODConsole.root.setForegroundColor(TCODColor.white);
            }
        }
        static void drawMap()
        {
            for (int i = 0; i < fieldWid; i++)
                for (int j = 0; j < fieldHei; j++)
                {
                    TCODConsole.root.setForegroundColor(level.Color[i, j]);
                    TCODConsole.root.print(Utils.WMapToDraw(i), Utils.HMapToDraw(j), level.sym[i, j].ToString());
                    TCODConsole.root.setForegroundColor(TCODColor.white);
                   
                }
        }
    }
}
