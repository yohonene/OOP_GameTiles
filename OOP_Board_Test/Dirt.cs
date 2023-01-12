﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test
{
    internal class Dirt : Tile
    {

        private String _icon = "D";

        private ConsoleColor _colour = ConsoleColor.DarkRed;

        public Dirt(int row, int col) 
        {
            this.Row = row;
            this.Col = col;
            this.Icon = _icon;
            this.Colour = _colour;
        }




    }
}
