using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test.Tiles
{
    internal class Iron : Tile
    {
        private string _icon = "Ī";
        private ConsoleColor _colour = ConsoleColor.DarkGray;
        private String name = "Iron";

        public Iron(int row, int col)
        {
            Row = row;
            Col = col;
            Icon = _icon;
            Colour = _colour;
            Name = name;
        }
    }
}
