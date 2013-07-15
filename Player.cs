using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;

namespace RiversideLegends
{
    public class Player : Monster
    {
        int exp;
        int expToNext;
        public int maxHP;
        public Player() : base ("Johnson", 1, '@')
        {
            maxHP = hp;
            expToNext = 100;
            recalcExp();
            color = TCODColor.lightAzure;
        }

        public void recalcExp()
        {
            expToNext = ((level - 1) * 25) + 100;
            maxHP = ((level - 1) * 5) + 30;
            hp = maxHP;
        }

        public List<bool> getGuiHP()
        {
            List<bool> toout = new List<bool>(100);
            toout.Capacity = 100;
            double perc = (double)hp / (double)maxHP;
            perc = (perc * 20) + 1;
            int temp = (int)perc;
            for (int i = 0; i < 21; i++)
            {
                toout.Add(false);
            }
            for (int i = 0; i < temp; i++)
            {
                toout[i] = true;
            }
            return toout;
        }

        public List<bool> getGuiEXP()
        {
            List<bool> toout = new List<bool>(100);
            toout.Capacity = 100;
            double perc = (double)exp / (double)expToNext;
            perc = (perc * 20) + 1;
            int temp = (int)perc;
            for (int i = 0; i < 21; i++)
            {
                toout.Add(false);
            }
            for (int i = 0; i < temp; i++)
            {
                toout[i] = true;
            }
            return toout;
        }
        public void heal(int par1)
        {
            if (par1 + hp > maxHP)
            {
                hp = maxHP;
            }
            else
            {
                hp += par1;
            }
        }
        public void regen()
        {
            if (1 + hp > maxHP)
            {
                hp = maxHP;
            }
            else
            {
                hp += 1;
            }
        }
        public void damage(int par1)
        {
            if (hp - par1 < 0)
            {
               
            }
            else
            {
                hp -= par1;
            }
        }

        public string getHp()
        {
            return hp + "/" + maxHP;
        }

        public void addExp(int par1)
        {
            if (exp + par1 >= expToNext)
            {
                exp = (exp + par1) - expToNext;
                level += 1;
                recalcExp();
            }
            else
            {
                exp += par1;
            }
        }
        public int getLevel()
        {
            return level;
        }

        public string getExpStr()
        {
            return exp + "/" + expToNext; 
        }

        public string getHpStr()
        {
            return hp + "/" + maxHP;
        }
    }
}
