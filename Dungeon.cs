using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;

namespace RiversideLegends
{
    public class Dungeon
    {
        public int width;
        public int height;
        public int[, ] data;
        public bool[, ] isWal;
        public bool[, ] isTra;
        public TCODColor[, ] Color;
        public char[, ] sym;
        //public List<Room> rooms;
        public Dungeon(int par1, int par2)
        {
            width = par1;
            height = par2;
            data = new int[width, height];
            isWal = new bool[width, height];
            isTra = new bool[width, height];
            Color = new TCODColor[width, height];
            sym = new char[width, height];
            clearMap();
            generate();
            //rooms = new List<Room>();
            //rooms.Clear();
        }
        public bool isWalkable(int par1, int par2)
        {
            if (isWal[par1, par2])
            {
                return true;
            }
            else return false;
        }

        public bool isTransparent(int par1, int par2)
        {
            if (isTra[par1, par2])
            {
                return true;
            }
            else return false;
        }

        public void clearMap()
        {

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    data[i, j] = 0;
                    isWal[i, j] = false;
                    isTra[i, j] = false;
                    Color[i, j] = TCODColor.white;
                    sym[i, j] = ' ';
                }
        }
        public void putBlood(int par1, int par2)
        {
            Color[par1, par2] = TCODColor.red;
        }
        public void generate()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    data[i, j] = 0;
                    //setColor(i, j);
                    //setOther(i, j);
                }
            }
            for (int i = 20; i < 70; i++)
            {
                for (int j = 20; j < 70; j++)
                {
                    data[i, j] = 1;
                    //setColor(i, j);
                    //setOther(i, j);
                }
            }
            for (int i = 19; i < 71; i++)
            {
                    data[i, 70] = 2;
                    data[i, 19] = 2;
                    //setColor(i, 70);
                    //setOther(i, 70);
                    //setColor(i, 19);
                    //setOther(i, 19);
            }
            for (int i = 19; i < 71; i++)
            {
                data[70, i] = 2;
                data[19, i] = 2;
                //setColor(70, i);
                //setOther(70, i);
                //setColor(19, i);
                //setOther(19, i);
            }
            data[3, 10] = 2;
            //setColor(3, 10);
            //setOther(3, 10);
            setAllPars();

        }
        void setAllPars()
        {
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    setColor(i, j);
                    setOther(i, j);
                }
        }
        void setOther(int i, int j)
        {
            switch(data[i, j])
            {
                case 0:
                    isWal[i, j] = false;
                    isTra[i, j] = false;
                    sym[i, j] = ' ';
                    break;
                case 1:
                    isWal[i, j] = true;
                    isTra[i, j] = true;
                    sym[i, j] = '.';
                    break;
                case 2:
                    isWal[i, j] = false;
                    isTra[i, j] = false;
                    sym[i, j] = '#';
                    break;
                case 3:
                    isWal[i, j] = false;
                    isTra[i, j] = true;
                    sym[i, j] = 'O';
                    break;
                case 4:
                    isWal[i, j] = true;
                    isTra[i, j] = true;
                    sym[i, j] = '=';
                    break;
                case 5:
                    isWal[i, j] = true;
                    isTra[i, j] = true;
                    sym[i, j] = '%';
                    break;
            }
        }
        public void setColor(int i, int j)
        {
            switch (data[i, j])
            {
                case 0: 
                    Color[i, j] = TCODColor.black;
                    break;
                case 1:
                    Color[i, j] = TCODColor.darkerGreen;
                    break;
                case 2:
                    Color[i, j] = TCODColor.darkGrey;
                    break;
                case 3:
                    Color[i, j] = TCODColor.lightestCyan;
                    break;
                case 4:
                    Color[i, j] = TCODColor.darkestRed;
                    break;
                case 5:
                    Color[i, j] = TCODColor.darkGreen;
                    break;
            }
        }
        //0 - void
        //1 - dirt floor
        //2 - stone wall
        //3 - window
        //4 - door
        //5 - staircase
    }
    
}
