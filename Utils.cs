using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiversideLegends
{
    public static class Utils
    {
        static Random rand;
        public static void initUtil()
        {
            rand = new Random();
        }

        public static int HMapToDraw(int par1)
        {
            return par1 + 12;
        }

        public static int WMapToDraw(int par1)
        {
            return par1 + 1;
        }
        public static bool randBool()
        {
            if (rand.Next(100) % 2 == 0)
            {
                
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int getRandom(int par1)
        {
            return rand.Next(par1);
        }

        public static int separateAtRange(int par1, float par2)
        {
            return rand.Next((int)(par1 - (par1/((par2+1)/par2))), (int)(par1/((par2+1)/par2))); 
        }
    }
}
