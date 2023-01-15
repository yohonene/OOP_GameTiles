using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Board_Test.Tiles
{
    internal class Stick : Tile
    {
        private string _icon = "/";
        private ConsoleColor _colour = ConsoleColor.DarkMagenta;
        private String name = "Stick";

        public Stick(int row, int col)
        {
            Row = row;
            Col = col;
            Icon = _icon;
            Colour = _colour;
            Name = name;
        }
    }
}
