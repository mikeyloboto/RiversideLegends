using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using libtcod;

namespace RiversideLegends
{
    public class Message
    {
        public String Text;
        public TCODColor Color;

        public Message()
        {
            Text = "";
            Color = TCODColor.white;
        }
        public Message(String par1, TCODColor par2)
        {
            Text = par1;
            Color = par2;
        }
        public Message(String par1)
        {
            Text = par1;
            Color = TCODColor.white;
        }
        public void setText(String par1)
        {
            Text = par1;
        }
        public void setColor(TCODColor par1)
        {
            Color = par1;
        }
    }
}
