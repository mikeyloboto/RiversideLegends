using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;

namespace RiversideLegends
{
    public class Monster
    {
        public static Monster wasp1 = new Monster("Wasp", 1, 'W');
        protected String name;
        protected int level;
        protected int baseDamage;
        protected int hp;
        public char sym;
        public int locX;
        public int locY;
        public TCODColor color;

        public Monster(String par1, int par2, char par3)
        {
            name = par1;
            level = par2;
            sym = par3;
            hp = 20 + (level * 3);
            baseDamage = 3 + (level * 2);
        }

        public int getDmg()
        {
            return baseDamage;
        }

        public TCODColor getClor(int par1)
        {
            if (par1 == level)
            {
                return TCODColor.lightRed;
            }
            else if (level < par1)
            {
                return TCODColor.lighterRed;
            }
            else
            {
                return TCODColor.red;
            }
        }
    }
}
